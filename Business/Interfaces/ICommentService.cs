using System.Threading.Tasks;
using Business.ViewModels.Comment;

namespace Business.Interfaces
{
    public interface ICommentService
    {
        Task Create(int productId, CommentVM commentVM);
        Task Remove(int id);
    }
}