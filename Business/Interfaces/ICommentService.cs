using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels.Comment;
using Core.Entities;

namespace Business.Interfaces
{
    public interface ICommentService
    {
        Task Create(int productId, CommentVM commentVM);
        Task Remove(int id);
        Task<List<Comment>> GetAllAsync();
    }
}