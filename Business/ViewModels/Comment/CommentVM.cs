using Core.Entities;

namespace Business.ViewModels.Comment
{
    public class CommentVM
    {
        public Product Product { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string CommentContent { get; set; }
        // public int ProductId { get; set; }
    }
}