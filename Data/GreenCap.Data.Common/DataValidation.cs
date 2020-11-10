namespace GreenCap.Data.Common
{
    public static class DataValidation
    {
        public const int NameTitleMaxLength = 30;
        public const int NameTitleMinLength = 3;
        public const int FullNameMaxLength = 60;

        public static class Comment
        {
            public const int ContentLength = 250;
        }

        public static class Proposal
        {
            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 30;

            public const int ShortDescriptionMaxLength = 100;
            public const int ShortDescriptionMinLength = 10;
        }

        public static class Post
        {
            public const int DescriptionMaxLength = 550;
            public const int DescriptionMinLength = 30;
        }

        public static class Events
        {
            public const int DescriptionMaxLength = 550;
            public const int DescriptionMinLength = 30;

            public const int ImagePathMaxLength = 1000;

            public const int TotalPeopleMaxCount = 10;
            public const int TotalPeopleMinCount = 1;
        }

        public static class Address
        {
            public const int CountryName = 30;
            public const int TownName = 30;
            public const int StreetName = 30;
        }
    }
}
