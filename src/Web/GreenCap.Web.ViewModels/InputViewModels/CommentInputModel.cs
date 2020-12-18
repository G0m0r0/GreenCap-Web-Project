namespace GreenCap.Web.ViewModels.InputViewModels
{
    public class CommentInputModel
    {
        public int PostId { get; set; }

        public int ParentId { get; set; }

        public string Content { get; set; }
    }
}
