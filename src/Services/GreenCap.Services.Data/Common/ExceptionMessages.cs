namespace GreenCap.Services.Data.Common
{
    public static class ExceptionMessages
    {
        public const string ProposalNotFound = "Proposal is not found!";

        public const string PostNotFound = "Post is not found!";

        public const string NewsNotFound = "Current article is not available!";

        public const string YouHaveToBeCreatorException = "You have to be creator of {0} in order to delete it!";

        public const string InvalidImageExtentionException = "Invalid image extension {0}!";

        public const string YouCanDeleteOnlyYourOwnCommentsException = "You can delete only your own comments!";

        public const string CommentNotFound = "This comment does not exist!";

        public const string CategoryNameDoesNotExist = "Category name does not exist!";

        public const string CategoryIsNull = "Category can not be null";

        public const string UserDoesNotExist = "User does not exist";

        public const string EventNotFound = "Event is not found!";

        public const string CanNotBeNegativeNumber = "{0} can not be negative number!";
    }
}
