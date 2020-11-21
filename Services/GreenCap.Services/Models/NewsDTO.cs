namespace GreenCap.Services.Models
{
    public class NewsDto
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Credit { get; set; }

        public string MainText { get; set; }

        public NewsShortIntroDTO ShortIntro { get; set; }
    }
}
