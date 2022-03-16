using System.Collections.Generic;
using System.Threading.Tasks;
using Business.ViewModels;
using Core.Entities;

namespace Business.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetAllAsync();
        Task<Paginate<Comment>> GetAllPaginatedAsync(int page);
        Task<Comment> GetAsync(int id);
        Task Create(Comment comment);
        Task Update(int id, Comment comment);
        Task Remove(int id);
        Task<int> getPageCount(int take);
    }
}