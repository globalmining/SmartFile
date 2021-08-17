using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FileManagementApp.Data;
using FileManagementApp.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace FileManagementApp.Controllers
{
    public class PDFsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PDFsController(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: PDFs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PDFs.Include(p => p.Group).Include(p => p.Item).Include(p => p.SubGroup);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PDFs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDF = await _context.PDFs
                .Include(p => p.Group)
                .Include(p => p.Item)
                .Include(p => p.SubGroup)
                .FirstOrDefaultAsync(m => m.PDFID == id);
            if (pDF == null)
            {
                return NotFound();
            }

            return View(pDF);
        }

        // GET: PDFs/Create
        public IActionResult Create()
        {

            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName");
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName");
            ViewData["SubGroupID"] = new SelectList(_context.SubGroups, "SubGroupID", "SubGroupName");
            return View();
        }

        // POST: PDFs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PDFID,Title,GroupID,SubGroupID,ItemID,PDFFile")] PDF pDF)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(pDF.PDFFile.FileName);
                string extension = Path.GetExtension(pDF.PDFFile.FileName);
                pDF.PDFName = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                //pDF.PDFName += Guid.NewGuid().ToString() + "_" + filename + extension;
                string path = Path.Combine(wwwRootPath + "/pdffolder/", filename);
                using (var flestream = new FileStream(path, FileMode.Create))
                {
                    await pDF.PDFFile.CopyToAsync(flestream);
                }
                pDF.CreateON = DateTime.UtcNow;
                pDF.UpdateON = DateTime.UtcNow;
                _context.Add(pDF);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName", pDF.GroupID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", pDF.ItemID);
            ViewData["SubGroupID"] = new SelectList(_context.SubGroups, "SubGroupID", "SubGroupName", pDF.SubGroupID);
            return View(pDF);
        }

        // GET: PDFs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDF = await _context.PDFs.FindAsync(id);
            if (pDF == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName", pDF.GroupID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", pDF.ItemID);
            ViewData["SubGroupID"] = new SelectList(_context.SubGroups, "SubGroupID", "SubGroupName", pDF.SubGroupID);
            return View(pDF);
        }

        // POST: PDFs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PDFID,Title,GroupID,SubGroupID,ItemID,PDFName,CreateON,UpdateON")] PDF pDF)
        {
            if (id != pDF.PDFID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pDF);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PDFExists(pDF.PDFID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName", pDF.GroupID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", pDF.ItemID);
            ViewData["SubGroupID"] = new SelectList(_context.SubGroups, "SubGroupID", "SubGroupName", pDF.SubGroupID);
            return View(pDF);
        }

        // GET: PDFs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDF = await _context.PDFs
                .Include(p => p.Group)
                .Include(p => p.Item)
                .Include(p => p.SubGroup)
                .FirstOrDefaultAsync(m => m.PDFID == id);
            if (pDF == null)
            {
                return NotFound();
            }

            return View(pDF);
        }

        // POST: PDFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pDF = await _context.PDFs.FindAsync(id);
            _context.PDFs.Remove(pDF);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PDFExists(int id)
        {
            return _context.PDFs.Any(e => e.PDFID == id);
        }

        [HttpPost]
        public IActionResult Import()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "UploadExcel";
            string webRootPath = _webHostEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            StringBuilder sb = new StringBuilder();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    sb.Append("<table class='table table-bordered'><tr>");
                    for (int j = 0; j < cellCount; j++)
                    {
                        NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                        sb.Append("<th>" + cell.ToString() + "</th>");
                    }
                    sb.Append("</tr>");
                    sb.AppendLine("<tr>");
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                sb.Append("<td>" + row.GetCell(j).ToString() + "</td>");
                        }
                        sb.AppendLine("</tr>");
                    }
                    sb.Append("</table>");
                }
            }
            return this.Content(sb.ToString());
        }

        
        public async Task<IActionResult> Export()
        {
            string sWebRootFolder = _webHostEnvironment.WebRootPath;
            string sFileName = @"Employees.xlsx";
            string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            var memory = new MemoryStream();
            using (var fs = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("employee");
                IRow row = excelSheet.CreateRow(0);

                row.CreateCell(0).SetCellValue("EmployeeId");
                row.CreateCell(1).SetCellValue("EmployeeName");
                row.CreateCell(2).SetCellValue("Age");
                row.CreateCell(3).SetCellValue("Sex");
                row.CreateCell(4).SetCellValue("Designation");

                row = excelSheet.CreateRow(1);
                row.CreateCell(0).SetCellValue(1);
                row.CreateCell(1).SetCellValue("Jack Supreu");
                row.CreateCell(2).SetCellValue(45);
                row.CreateCell(3).SetCellValue("Male");
                row.CreateCell(4).SetCellValue("Solution Architect");

                row = excelSheet.CreateRow(2);
                row.CreateCell(0).SetCellValue(2);
                row.CreateCell(1).SetCellValue("Steve khan");
                row.CreateCell(2).SetCellValue(33);
                row.CreateCell(3).SetCellValue("Male");
                row.CreateCell(4).SetCellValue("Software Engineer");

                row = excelSheet.CreateRow(3);
                row.CreateCell(0).SetCellValue(3);
                row.CreateCell(1).SetCellValue("Romi gill");
                row.CreateCell(2).SetCellValue(25);
                row.CreateCell(3).SetCellValue("FeMale");
                row.CreateCell(4).SetCellValue("Junior Consultant");

                row = excelSheet.CreateRow(4);
                row.CreateCell(0).SetCellValue(4);
                row.CreateCell(1).SetCellValue("Hider Ali");
                row.CreateCell(2).SetCellValue(34);
                row.CreateCell(3).SetCellValue("Male");
                row.CreateCell(4).SetCellValue("Accountant");

                row = excelSheet.CreateRow(5);
                row.CreateCell(0).SetCellValue(5);
                row.CreateCell(1).SetCellValue("Mathew");
                row.CreateCell(2).SetCellValue(48);
                row.CreateCell(3).SetCellValue("Male");
                row.CreateCell(4).SetCellValue("Human Resource");

                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, sFileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", sFileName);
        }
        public ActionResult Download()
        {
            string Files = "wwwroot/UploadExcel";
            byte[] fileBytes = System.IO.File.ReadAllBytes(Files);
            System.IO.File.WriteAllBytes(Files, fileBytes);
            MemoryStream ms = new MemoryStream(fileBytes);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "employee.xlsx");
        }

        public IActionResult IndexExcel()
        {
            return View();
        }
    }
}
