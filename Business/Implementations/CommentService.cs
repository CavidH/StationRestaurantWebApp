using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using Business.ViewModels.Comment;
using Core;
using Core.Entities;

namespace Business.Implementations
{
    public class CommentService : ICommentService
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

        public async Task Create(int productId, CommentVM commentVM)
        {
            var comment = new Comment
            {
                FullName = commentVM.FullName,
                Email = commentVM.Email,
                Subject = commentVM.Subject,
                CommentContent = commentVM.Subject,
                CreatedAt = DateTime.Now,
                ProductId = productId
            };
            await _unitOfWork.commentRepository.CreateAsync(comment);
            await _unitOfWork.SaveAsync();
        }


        public async Task Update(int id, Comment comment)
        {
            throw new System.NotImplementedException();
        }

        public async Task Remove(int id)
        {
            var comment = await _unitOfWork.commentRepository.GetAsync(p => p.Id == id && p.IsDeleted == false);
            comment.IsDeleted = true;
            _unitOfWork.commentRepository.Update(comment);
            await _unitOfWork.SaveAsync();
        }

        public async Task<int> getPageCount(int take)
        {
            throw new System.NotImplementedException();
        }
    }
}