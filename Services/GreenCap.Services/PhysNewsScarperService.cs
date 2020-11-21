namespace GreenCap.Services
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    using AngleSharp;
    using GreenCap.Services.Models;

    public class PhysNewsScarperService : IPhysNewsScarperService
    {
        private const string BaseUrl = "https://phys.org/biology-news/ecology/sort/date/all/page{0}.html";

        private readonly IConfiguration config;
        private readonly IBrowsingContext context;

        public PhysNewsScarperService()
        {
            this.config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(this.config);
        }

        public async Task ImportNewsAsync(int countPages)
        {
            var concurrentBagNews = this.ScraperNews(countPages);

            foreach (var news in concurrentBagNews)
            {
            }
        }

        private ConcurrentBag<NewsDto> ScraperNews(int countPages)
        {
            var concurrentBag = new ConcurrentBag<NewsDto>();

            Parallel.For(1, countPages, i =>
            {
                try
                {
                    var newsColletion = this.GetNews(i);
                    foreach (var item in newsColletion)
                    {
                        concurrentBag.Add(item);
                    }
                }
                catch
                {
                    // ignored
                }
            });

            return concurrentBag;
        }

        private List<NewsDto> GetNews(int id)
        {
            var newsList = new List<NewsDto>();

            var url = string.Format(BaseUrl, id);

            var document = this.context
                .OpenAsync(url)
                .GetAwaiter()
                .GetResult();

            if (document.StatusCode == HttpStatusCode.NotFound ||
                document.DocumentElement.OuterHtml.Contains("Ooops... 404 Error"))
            {
                throw new InvalidOperationException();
            }

            var shortNews = new NewsShortIntroDTO();
            var mainNews = new NewsDto();

            var news = document.GetElementsByClassName("sorted-article");

            foreach (var x in news)
            {
                shortNews.MainPageUrl = x.GetElementsByClassName("sorted-article-figure")[0]
                                .GetElementsByTagName("img")[0]
                                .GetAttribute("data-src");

                shortNews.MainPhotoUrl = x.GetElementsByClassName("sorted-article-figure")[0]
                                .GetElementsByTagName("a")[0]
                                .GetAttribute("href");

                shortNews.Title = x.GetElementsByClassName("sorted-article-content")[0]
                                .GetElementsByTagName("a")[0]
                                .TextContent;

                shortNews.ShortIntro = x.GetElementsByClassName("sorted-article-content")[0]
                               .GetElementsByTagName("p")[0]
                               .TextContent
                               .Trim();

                shortNews.CategoryName = x.GetElementsByClassName("article__info")[0]
                                .GetElementsByTagName("p")[0]
                                .TextContent
                                .Trim();

                shortNews.PostedOn = x.GetElementsByClassName("article__info")[0]
                                .GetElementsByTagName("p")[1]
                                .TextContent
                                .Trim();

                var mainUrl = shortNews.MainPageUrl;

                var doc = this.context
                    .OpenAsync(mainUrl)
                    .GetAwaiter()
                    .GetResult();

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

                newsList.Add(mainNews);
            }

            return newsList;
        }
    }
}
