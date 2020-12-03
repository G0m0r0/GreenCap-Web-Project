namespace GreenCap.Services.Data.Common
{
    public static class ExceptionMessages
    {
        public const string ProposalNotFound = "Proposal with title {0} is not found!";

        public const string PostNotFound = "Post with title {0} is not found!";

        public const string NewsNotFound = "Current article is not available!";

        public const string YouHaveToBeCreatorException = "You have to be creator of {0} in order to delete it!";

        public const string InvalidImageExtentionException = "Invalid image extension {0}!";

        public const string YouCanDeleteOnlyYourOwnCommentsException = "You can delete only your own comments!";

        public const string CommentNotFound = "This comment does not exist!";
    }
}
