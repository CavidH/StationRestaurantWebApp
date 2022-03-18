using System;
using System.IO;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Utilities;
using Business.ViewModels.ProductVM;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public ProductController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }


        public async Task<IActionResult> Index(int page = 1)
        {
            return View(await _unitOfWorkService.productService.GetAllPaginatedAsync(page));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await _unitOfWorkService.productCategoryService.GetAllAsync();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ProductPostVM productPostVm)
        {
            ViewBag.categories = await _unitOfWorkService.productCategoryService.GetAllAsync();
            if (ModelState.IsValid)
            {
                if (!productPostVm.ImageFile.CheckFileType("image/"))
                {
                    ModelState.AddModelError("ImageFile", "file  should be  image type ");
                    return View(productPostVm);
                }

                if (!productPostVm.ImageFile.CheckFileSize(300))
                {
                    ModelState.AddModelError("ImageFile", "file size must be less than 200kb");
                    return View(productPostVm);
                }

                try
                {
                    await _unitOfWorkService.productService.Create(productPostVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(productPostVm);
                }

                return RedirectToAction(nameof(Index));
            }

            // check error
            // return RedirectToAction(nameof(Create));
            return View(productPostVm);
        }

        public async Task<IActionResult> Update(int id)
        {
            if (id < 0) return BadRequest();
            var product = await _unitOfWorkService.productService.GetAsync(id);
            if (product == null) return NotFound();
            ViewBag.categories = await _unitOfWorkService.productCategoryService.GetAllAsync();
            return View(new ProductUpdateVM()
            {
                Name = product.Name,
                Title = product.Title,
                Description = product.Title,
                ProductCategoryID = product.ProductCategoryID,
                Price = product.Price
            });
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(int id, ProductUpdateVM productUpdateVm)
        {
            ViewBag.categories = await _unitOfWorkService.productCategoryService.GetAllAsync();

            if (ModelState.IsValid)
            {
                if (productUpdateVm.ImageFile != null)
                {
                    if (!productUpdateVm.ImageFile.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("ImageFile", "file  should be  image type ");
                        return View(productUpdateVm);
                    }

                    if (!productUpdateVm.ImageFile.CheckFileSize(300))
                    {
                        ModelState.AddModelError("ImageFile", "file size must be less than 200kb");
                        return View(productUpdateVm);
                    }
                }

                try
                {
                    await _unitOfWorkService.productService.Update(id, productUpdateVm);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(productUpdateVm);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(productUpdateVm);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            try
            {
                await _unitOfWorkService.productService.Remove(id);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        // public IActionResult ExportToExcel()
        // {
        //     using (var workbook = new XLWorkbook())
        //     {
        //         var worksheet = workbook.Worksheets.Add("Contacts");
        //         var currentRow = 1;
        //         worksheet.Cell(currentRow, 1).Value = "Id";
        //         worksheet.Cell(currentRow, 2).Value = "Firstname";
        //         worksheet.Cell(currentRow, 3).Value = "Middlename";
        //         worksheet.Cell(currentRow, 4).Value = "Lastname";
        //         worksheet.Cell(currentRow, 5).Value = "Prefix";
        //         worksheet.Cell(currentRow, 6).Value = "Suffix";
        //         worksheet.Cell(currentRow, 7).Value = "Phoneticfirst";
        //         worksheet.Cell(currentRow, 8).Value = "Phoneticmiddle";
        //         worksheet.Cell(currentRow, 9).Value = "Phoneticlast";
        //         worksheet.Cell(currentRow, 10).Value = "Nickname";
        //         worksheet.Cell(currentRow, 11).Value = "Company";
        //         worksheet.Cell(currentRow, 12).Value = "Phone";
        //         worksheet.Cell(currentRow, 13).Value = "Department";
        //         worksheet.Cell(currentRow, 14).Value = "Country";
        //         worksheet.Cell(currentRow, 15).Value = "City";
        //         worksheet.Cell(currentRow, 16).Value = "StreetAddress";
        //         worksheet.Cell(currentRow, 17).Value = "Postalcode";
        //         worksheet.Cell(currentRow, 18).Value = "Jobtitle";
        //         worksheet.Cell(currentRow, 19).Value = "Birthday";
        //         worksheet.Cell(currentRow, 20).Value = "Website";
        //         worksheet.Cell(currentRow, 21).Value = "Email";
        //         worksheet.Cell(currentRow, 22).Value = "Note";
        //         worksheet.Cell(currentRow, 23).Value = "isDeleted";
        //         worksheet.Cell(currentRow, 24).Value = "Favorite";
        //
        //
        //         worksheet.Cell(currentRow, 1).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 2).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 3).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 4).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 5).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 6).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 7).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 8).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 9).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 10).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 11).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 12).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 13).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 14).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 15).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 16).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 17).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 18).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 19).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 20).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 21).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 22).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 23).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //         worksheet.Cell(currentRow, 24).Style.Fill.SetBackgroundColor(XLColor.LightGray);
        //
        //
        //         foreach (var contact in _context.Contacts.Where(c => c.IsDeleted == false))
        //         {
        //             currentRow++;
        //             worksheet.Cell(currentRow, 1).Value = contact.Id;
        //             worksheet.Cell(currentRow, 2).Value = contact.Firstname;
        //             worksheet.Cell(currentRow, 3).Value = contact.Middlename;
        //             worksheet.Cell(currentRow, 4).Value = contact.Lastname;
        //             worksheet.Cell(currentRow, 5).Value = contact.Prefix;
        //             worksheet.Cell(currentRow, 6).Value = contact.Suffix;
        //             worksheet.Cell(currentRow, 7).Value = contact.Phoneticfirst;
        //             worksheet.Cell(currentRow, 8).Value = contact.Phoneticmiddle;
        //             worksheet.Cell(currentRow, 9).Value = contact.Phoneticlast;
        //             worksheet.Cell(currentRow, 10).Value = contact.Nickname;
        //             worksheet.Cell(currentRow, 11).Value = contact.Company;
        //             worksheet.Cell(currentRow, 12).Value = contact.Phone;
        //             worksheet.Cell(currentRow, 13).Value = contact.Department;
        //             worksheet.Cell(currentRow, 14).Value = contact.Country;
        //             worksheet.Cell(currentRow, 15).Value = contact.City;
        //             worksheet.Cell(currentRow, 16).Value = contact.StreetAddress;
        //             worksheet.Cell(currentRow, 17).Value = contact.Postalcode;
        //             worksheet.Cell(currentRow, 18).Value = contact.Jobtitle;
        //             worksheet.Cell(currentRow, 19).Value = contact.Birthday;
        //             worksheet.Cell(currentRow, 20).Value = contact.Website;
        //             worksheet.Cell(currentRow, 21).Value = contact.Email;
        //             worksheet.Cell(currentRow, 22).Value = contact.Note;
        //             worksheet.Cell(currentRow, 23).Value = contact.IsDeleted;
        //             worksheet.Cell(currentRow, 24).Value = contact.Favorite;
        //         }
        //
        //         using (var stream = new MemoryStream())
        //         {
        //             workbook.SaveAs(stream);
        //             var content = stream.ToArray();
        //             return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        //                 "ContactReport.xlsx");
        //         }
        //     }
        // }
    }
}