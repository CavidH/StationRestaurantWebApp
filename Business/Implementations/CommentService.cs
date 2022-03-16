using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Core;
using Core.Entities;

namespace Business.Implementations
{
    public class CommentService:ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Paginate<Comment>> GetAllPaginatedAsync(int page)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Comment> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Create(Comment comment)
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(int id, Comment comment)
        {
            throw new System.NotImplementedException();
        }

        public async Task Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> getPageCount(int take)
        {
            throw new System.NotImplementedException();
        }
    }
}