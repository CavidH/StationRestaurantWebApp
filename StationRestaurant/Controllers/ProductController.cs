using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public ProductController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (id == 0) return NotFound();
            try
            {
                var product = await _unitOfWorkService.productService.GetAsync(id);
                if (product == null) return NotFound();
                var commentVM = new CommentVM
                {
                    Product = product
                };

                return View(commentVM);
            }
            catch (Exception e)
            {
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id, CommentVM commentVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWorkService.commentService.Create(id, commentVm);
                    return Redirect($"/Product?id={id}");
                }
                catch (Exception e)
                {
                    commentVm.Product = await _unitOfWorkService.productService.GetAsync(id);
                    View(commentVm);
                }
            }

            commentVm.Product = await _unitOfWorkService.productService.GetAsync(id);
            return View(commentVm);
        }


        public async Task<IActionResult> Delete( int id,string returnurl)
        {
            if (id == 0) return NotFound();
            try
            {
                await _unitOfWorkService.commentService.Remove(id);
                // var product = await _unitOfWorkService.productService.GetAsync(id);
                // if (product==null) return NotFound();
                // var commentVM = new CommentVM
                // {
                //     Product = product
                // };
                //
                // return View(commentVM);
                return Redirect(returnurl);
            }
            catch (Exception e)
            {
            }

            return RedirectToAction("Index", "Home");
        }
    }
}