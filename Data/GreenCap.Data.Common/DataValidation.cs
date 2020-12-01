namespace GreenCap.Data.Common
{
    public static class DataValidation
    {
        public const ushort NameTitleMaxLength = 500;
        public const byte NameTitleMinLength = 3;

        public const byte FullNameMaxLength = 60;

        public const ushort UrlPathMaxLength = 1000;
        public const byte UrlPathMinLegth = 5;

        public static class Comment
        {
            public const ushort ContentLength = 500;
        }

        public static class Proposal
        {
            public const ushort DescriptionMaxLength = 10_000;
            public const byte DescriptionMinLength = 20;

            public const ushort ShortDescriptionMaxLength = 500;
            public const byte ShortDescriptionMinLength = 10;
        }

        public static class Post
        {
            public const ushort DescriptionMaxLength = 20_000;
            public const byte DescriptionMinLength = 10;
            public const byte ShortDescriptionMaxLength = 200;
            public const byte ShortDescriptionMinLength = 0;
        }

        public static class Events
        {
            public const ushort DescriptionMaxLength = 15_000;
            public const byte DescriptionMinLength = 10;

            public const byte TotalPeopleMaxCount = 100;
            public const byte TotalPeopleMinCount = 1;
        }

        public static class Address
        {
            public const byte CountryNameMaxLength = 100;
            public const byte CountryNameMinLength = 100;

            public const byte TownNameMaxLength = 100;
            public const byte TownNameMinLength = 100;

            public const byte StreetNameMaxLength = 100;
            public const byte StreetNameMinLength = 100;
        }

        public static class News
        {
            public const byte PostedOnMaxLength = 30;
            public const byte PostedOnMinLength = 3;

            public const ushort SummaryMaxLength = 1000;
            public const byte SummaryMinLength = 10;

            public const ushort CreditMaxLength = 1000;
            public const byte CreaditMinLegth = 3;

            public const ushort DescriptionMaxLength = 50_000;
            public const byte DescriptionMinLength = 10;
        }
    }
}
