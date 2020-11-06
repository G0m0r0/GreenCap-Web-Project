namespace GreenCap.Data.Common
{
    public static class DataValidation
    {
        public const int NameTitleMaxLength = 30;
        public const int FullNameMaxLength = 60;

        public static class Comment
        {
            public const int ContentLength = 250;
        }

        public static class Idea
        {
            public const int ImagePathLength = 500;
            public const int DescriptionLength = 1000;
            public const int ShortLength = 100;
        }

        public static class Post
        {
            public const int Description = 550;
        }

        public static class Events
        {
            public const int Description = 550;
        }

        public static class Address
        {
            public const int CountryName = 30;
            public const int TownName = 30;
            public const int StreetName = 30;
        }
    }
}
