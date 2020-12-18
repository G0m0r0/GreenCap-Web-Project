namespace GreenCap.Services
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using AngleSharp;
    using GreenCap.Data.Common.Repositories;
    using GreenCap.Data.Models;
    using GreenCap.Services.Models;

    public class PhysNewsScarperService : IPhysNewsScarperService
    {
        private const string BaseUrl = "https://phys.org/biology-news/ecology/sort/date/all/page{0}.html";

        private readonly IConfiguration config;
        private readonly IBrowsingContext context;
        private readonly IDeletableEntityRepository<CategoryNews> categoryDb;
        private readonly IDeletableEntityRepository<News> newsDb;

        public PhysNewsScarperService(
            IDeletableEntityRepository<CategoryNews> categoryDb,
            IDeletableEntityRepository<News> newsDb)
        {
            this.config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(this.config);
            this.categoryDb = categoryDb;
            this.newsDb = newsDb;
        }

        public async Task ImportNewsAsync(int countNews)
        {
            var concurrentBagNews = this.ScraperNews(countNews);

            foreach (var news in concurrentBagNews)
            {
                var categoryId = await this.GetOrCreateCategoryAsync(news.ShortIntro.CategoryName);

                var newsExist = this.newsDb
                    .AllAsNoTracking()
                    .Any(x => x.Title == news.Title);

                if (newsExist)
                {
                    continue;
                }

                var newNews = new News
                {
                    Title = news.Title,
                    CategoryId = categoryId,
                    Credit = news.Credit,
                    Description = news.MainText,
                    ImageSmallUrl = news.ShortIntro.SmallPhotoUrl,
                    ImageUrl = news.ImageUrl,
                    OriginalUrl = news.ShortIntro.MainPageUrl,
                    PostedOn = news.ShortIntro.PostedOn,
                    Summary = news.ShortIntro.Summary,
                };

                await this.newsDb.AddAsync(newNews);
                await this.newsDb.SaveChangesAsync();
            }
        }

        private async Task<int> GetOrCreateCategoryAsync(string categoryName)
        {
            var category = this.categoryDb
                .AllAsNoTracking()
                .FirstOrDefault(x => x.Name == categoryName);

            if (category != null)
            {
                return category.Id;
            }

            category = new CategoryNews
            {
                Name = categoryName,
            };

            await this.categoryDb.AddAsync(category);
            await this.categoryDb.SaveChangesAsync();

            return category.Id;
        }

        private ConcurrentBag<NewsDto> ScraperNews(int countNews)
        {
            var concurrentBag = new ConcurrentBag<NewsDto>();

            // count news
            Parallel.For(0, countNews, i =>
            {
                try
                {
                    var news = this.GetNews(i);

                    concurrentBag.Add(news);
                }
                catch
                {
                    // ignored
                }
            });

            return concurrentBag;
        }

        private NewsDto GetNews(int countNews)
        {
            int currentPage;
            int newsNumber;

            if (countNews < ServicesConstants.NumberOfNewsOnPage)
            {
                currentPage = 1;
            }
            else
            {
                currentPage = (countNews / ServicesConstants.NumberOfNewsOnPage) + 1;
            }

            newsNumber = countNews % ServicesConstants.NumberOfNewsOnPage;

            var url = string.Format(BaseUrl, currentPage);

            var document = this.context
                .OpenAsync(url)
                .GetAwaiter()
                .GetResult();

            // prevent block from the site
            // Thread.Sleep(1000);
            if (document.StatusCode == HttpStatusCode.NotFound ||
                document.DocumentElement.OuterHtml.Contains(ServicesConstants.ErrorMessageIfArticleDoesNotExist))
            {
                throw new InvalidOperationException();
            }

            var shortNews = new NewsShortIntroDTO();
            var mainNews = new NewsDto();

            var x = document.GetElementsByClassName("sorted-article")[newsNumber];

            shortNews.MainPageUrl = x.GetElementsByClassName("sorted-article-figure")[0]
                            .GetElementsByTagName("a")[0]
                            .GetAttribute("href");

            shortNews.SmallPhotoUrl = x.GetElementsByClassName("sorted-article-figure")[0]
                            .GetElementsByTagName("img")[0]
                            .GetAttribute("data-src");

            shortNews.Title = x.GetElementsByClassName("sorted-article-content")[0]
                            .GetElementsByTagName("a")[0]
                            .TextContent;

            shortNews.Summary = x.GetElementsByClassName("sorted-article-content")[0]
                           .GetElementsByTagName("p")[0]
                           .TextContent
                           .Trim();

            shortNews.CategoryName = x.GetElementsByClassName("article__info")[0]
                            .GetElementsByTagName("p")[0]
                            .TextContent
                            .Trim();

            var date = x.GetElementsByClassName("article__info")[0]
                            .GetElementsByTagName("p")[1]
                            .TextContent
                            .Trim();

            if (date.ToLower().Contains(ServicesConstants.DateTimeHoursStringToLower) ||
                date.ToLower().Contains(ServicesConstants.DateTimeMinutesStringToLower) ||
                date.ToLower().Contains(ServicesConstants.DateTimeMinuteStringToLower) ||
                date.ToLower().Contains(ServicesConstants.DateTimeMinuteStringToLower))
            {
                date = DateTime.Now.ToString(ServicesConstants.DateTimeFormat);
            }

            shortNews.PostedOn = date;

            var mainUrl = shortNews.MainPageUrl;

            var doc = this.context
                .OpenAsync(mainUrl)
                .GetAwaiter()
                .GetResult();

            // prevent block from the site
            // Thread.Sleep(1000);
            mainNews.Title = doc.GetElementsByClassName("news-article")[0].GetElementsByTagName("h1")[0].TextContent;
            mainNews.ImageUrl = doc.GetElementsByClassName("article-img")[0].GetElementsByTagName("img")[0].GetAttribute("src");
            mainNews.Credit = doc.GetElementsByClassName("article-img")[0].GetElementsByTagName("figcaption")[0].TextContent.Trim();

            var textParagraphs = doc.GetElementsByClassName("article-main")[0].GetElementsByTagName("p");
            var sb = new StringBuilder();
            foreach (var paragraph in textParagraphs)
            {
                sb.AppendLine(paragraph.TextContent.Trim());
                sb.AppendLine();
            }

            mainNews.MainText = sb.ToString().TrimEnd();

            mainNews.ShortIntro = shortNews;

            return mainNews;
        }
    }
}
