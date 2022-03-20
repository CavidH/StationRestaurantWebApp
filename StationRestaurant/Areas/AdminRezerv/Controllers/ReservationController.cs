using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.ViewModels;
using ClosedXML.Excel;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StationRestaurant.Areas.AdminRezerv.Controllers
{
    [Area("AdminRezerv")]
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public ReservationController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.tables = await _unitOfWorkService.tableService.GetAllAsync();
            return View(await _unitOfWorkService.reservationService.GetAllPaginatedAsync(page));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(Paginate<Reservation> paginate, int page = 1)
        {
            ViewBag.tables = await _unitOfWorkService.tableService.GetAllAsync();
            return View(
                await _unitOfWorkService.reservationService.GetAllPaginatedAsync(page, paginate.Item.ReservDate.Date));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1) return BadRequest();
            await _unitOfWorkService.reservationService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Clean()
        {
            await _unitOfWorkService.reservationService.Clean();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ExportToExcelToday()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reservations");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Firstname";
                worksheet.Cell(currentRow, 3).Value = "LastName";
                worksheet.Cell(currentRow, 4).Value = "PhoneNumber";
                worksheet.Cell(currentRow, 5).Value = "Email";
                worksheet.Cell(currentRow, 6).Value = "Table";
                worksheet.Cell(currentRow, 7).Value = "ReservDate";
                worksheet.Cell(currentRow, 8).Value = "ReservEndDate";
                worksheet.Cell(currentRow, 9).Value = "IsActive";
                worksheet.Cell(currentRow, 10).Value = "Additionals";

                worksheet.Cell(currentRow, 1).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 2).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 3).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 4).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 5).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 6).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 7).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 8).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 9).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 10).Style.Fill.SetBackgroundColor(XLColor.LightGray);


                foreach (var contact in (await _unitOfWorkService.reservationService.GetAllAsync()).Where(p =>
                             p.ReservDate.Date == DateTime.Now.Date))
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = contact.Id;
                    worksheet.Cell(currentRow, 2).Value = contact.Name;
                    worksheet.Cell(currentRow, 3).Value = contact.LastName;
                    worksheet.Cell(currentRow, 4).Value = contact.PhoneNumber;
                    worksheet.Cell(currentRow, 5).Value = contact.Email;
                    worksheet.Cell(currentRow, 6).Value = contact.Table.TableNumber;
                    worksheet.Cell(currentRow, 7).Value = contact.ReservDate;
                    worksheet.Cell(currentRow, 8).Value = contact.ReservEndDate;
                    if (contact.IsActive)
                    {
                        worksheet.Cell(currentRow, 9).Value = "ACTIVE";
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 9).Value = "DEACTIVE";
                    }

                    worksheet.Cell(currentRow, 10).Value = contact.Additionals;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"Reservation_{DateTime.Now.ToString()}.xlsx");
                }
            }
        }
        
        
        public async Task<IActionResult> ExportToExcelAll()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reservations");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Firstname";
                worksheet.Cell(currentRow, 3).Value = "LastName";
                worksheet.Cell(currentRow, 4).Value = "PhoneNumber";
                worksheet.Cell(currentRow, 5).Value = "Email";
                worksheet.Cell(currentRow, 6).Value = "Table";
                worksheet.Cell(currentRow, 7).Value = "ReservDate";
                worksheet.Cell(currentRow, 8).Value = "ReservEndDate";
                worksheet.Cell(currentRow, 9).Value = "IsActive";
                worksheet.Cell(currentRow, 10).Value = "Additionals";

                worksheet.Cell(currentRow, 1).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 2).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 3).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 4).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 5).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 6).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 7).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 8).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 9).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                worksheet.Cell(currentRow, 10).Style.Fill.SetBackgroundColor(XLColor.LightGray);


                foreach (var contact in (await _unitOfWorkService.reservationService.GetAllStatAsync()))
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = contact.Id;
                    worksheet.Cell(currentRow, 2).Value = contact.Name;
                    worksheet.Cell(currentRow, 3).Value = contact.LastName;
                    worksheet.Cell(currentRow, 4).Value = contact.PhoneNumber;
                    worksheet.Cell(currentRow, 5).Value = contact.Email;
                    worksheet.Cell(currentRow, 6).Value = contact.Table.TableNumber;
                    worksheet.Cell(currentRow, 7).Value = contact.ReservDate;
                    worksheet.Cell(currentRow, 8).Value = contact.ReservEndDate;
                    if (contact.IsActive)
                    {
                        worksheet.Cell(currentRow, 9).Value = "ACTIVE";
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 9).Value = "DEACTIVE";
                    }

                    worksheet.Cell(currentRow, 10).Value = contact.Additionals;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"AllReservation_{DateTime.Now.ToString()}.xlsx");
                }
            }
        }
    }
}