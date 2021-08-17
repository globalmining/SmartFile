using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileManagementApp.Data;
using FileManagementApp.Models;
using FileManagementApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dapper;
namespace FileManagementApp.Controllers
{
    public class ManageInventory : Controller
    {
        private readonly ApplicationDbContext _context;
        public ManageInventory(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<string> MonthList = new List<string>();
            List<string> YearList = new List<string>();
            MonthList.Add("January");
            MonthList.Add("February");
            MonthList.Add("March");
            MonthList.Add("April");
            MonthList.Add("May");
            MonthList.Add("June");
            MonthList.Add("July");
            MonthList.Add("August");
            MonthList.Add("September");
            MonthList.Add("Octomber");
            MonthList.Add("November");
            MonthList.Add("December");

            YearList.Add("2019");
            YearList.Add("2020");
            YearList.Add("2021");
            YearList.Add("2022");
            YearList.Add("2023");
            YearList.Add("2024");
            YearList.Add("2025");

            ViewData["GroupID"] = new SelectList(_context.Groups.Where(x=>x.GroupID == 4), "GroupID", "GroupName");
            ViewData["ItemID"] = new SelectList(_context.Items.Where(x=>x.GroupID == 4), "ItemID", "ItemName");
            ViewData["Years"] = new SelectList(YearList.ToList(), "", "");
            ViewData["Months"] = new SelectList(MonthList.ToList(), "", "");
            return View();
        }
        //string GroupName,string ItemName,string Unit,decimal LastBalQty, decimal PurchaseQty, decimal SaleQty, decimal StockQty, decimal Rate
       [HttpPost]
        public JsonResult AddStockDetails(StockDetails data,string Date)
        {
            try
            {
                //StockDetails Data = new StockDetails();
                //Data.GroupName = GroupName;
                //Data.ItemName = ItemName;
                //Data.Unit = Unit;
                //Data.LastBalQty = LastBalQty;
                //Data.PurchaseQty = PurchaseQty;
                //Data.SaleQty = SaleQty;
                //Data.StockQty = StockQty;
                //Data.Rate = Rate;
                string Month, Year;
                if (Date != null)
                {
                    DateTime date = Convert.ToDateTime(Date);
                    Month = date.ToString("MMMM");
                    Year = date.ToString("yyyy");
                }
                else
                {
                    Month = DateTime.Now.ToString("MMMM");
                    Year = DateTime.Now.ToString("yyyy");
                }

                StockMain main = new StockMain();
                main.MonthYear = Month + " - " + Year;
                bool IsMainAvailable = _context.StockMains.Any(x => x.MonthYear == main.MonthYear);
                if (!IsMainAvailable)
                {
                    main.Date = DateTime.Now;
                    _context.StockMains.Add(main);
                    _context.SaveChanges();
                }
                else
                {
                    main = _context.StockMains.FirstOrDefault(x => x.MonthYear == main.MonthYear);
                }
                data.StockMainID = main.StockMainID;
                data.Amount = data.Rate * data.StockQty;
                bool IsDetailsAvailable = _context.StockDetails.Any(x => x.StockMainID == main.StockMainID && x.ItemName == data.ItemName && x.GroupName == data.GroupName);
                if (!IsDetailsAvailable)
                {
                    _context.StockDetails.Add(data);
                }
                else
                {
                     StockDetails stock = _context.StockDetails.FirstOrDefault(x => x.StockMainID == main.StockMainID && x.ItemName == data.ItemName && x.GroupName == data.GroupName);
                    stock.Unit = data.Unit;
                    stock.Amount = data.Amount;
                    stock.GroupName = data.GroupName;
                    stock.ItemName = data.ItemName;
                    stock.LastBalQty = data.LastBalQty;
                    stock.PurchaseQty = data.PurchaseQty;
                    stock.Rate = data.Rate;
                    stock.SaleQty = data.SaleQty;
                    stock.StockQty = data.StockQty;
                    _context.StockDetails.Update(stock);
                }
                _context.SaveChanges();
                return Json(true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet]
        public JsonResult GetStockDetails(string Date)
        {
            List<StockDetails> Details = new List<StockDetails>();
            try
            {
                
                string Month, Year;
                if (Date != null)
                {
                    DateTime date = Convert.ToDateTime(Date);
                    Month = date.ToString("MMMM");
                    Year = date.ToString("yyyy");
                }
                else
                {
                    Month = DateTime.Now.ToString("MMMM");
                    Year = DateTime.Now.ToString("yyyy");
                } 
                string Monthyear = Month + " - " + Year;
                var Stock = _context.StockMains.FirstOrDefault(x => x.MonthYear == Monthyear);

                if (Stock != null)
                {
                    var Data = _context.StockDetails.Where(x => x.StockMainID == Stock.StockMainID).ToList();
                    if (Data == null)
                    {
                        Data = new List<StockDetails>();
                    }
                    else
                    {
                        Details = Data;
                    }

                }
                return Json(Details);
            }
            catch (Exception ex)
            {
                return Json(false);
                throw;
            }
        }
        public JsonResult GetStockDetailsById(int id)
        {
            var Data = _context.StockDetails.FirstOrDefault(x => x.StockDetailID == id);
            return Json(Data);
           
        }
        public JsonResult GetTotalAmount(string Date)
            {
            string Month, Year;
            if (Date != null)
            {
                DateTime date = Convert.ToDateTime(Date);
                Month = date.ToString("MMMM");
                Year = date.ToString("yyyy");
            }
            else
            {
                Month = DateTime.Now.ToString("MMMM");
                Year = DateTime.Now.ToString("yyyy");
            }
            string Monthyear = Month + " - " + Year;
            var Stock = _context.StockMains.FirstOrDefault(x => x.MonthYear == Monthyear);
            if (Stock != null)
            {
                var Data = _context.StockDetails.Where(x => x.StockMainID == Stock.StockMainID).Select(x => x.Amount).ToList();
                return Json(Data.Sum());
            }
            else
            {
                return Json(false);
            }
           
        }
        public JsonResult AddStockMains(StockMain main,string Date)
        {
            string Month, Year;
            if (Date != null)
            {
                DateTime date = Convert.ToDateTime(Date);
                Month = date.ToString("MMMM");
                Year = date.ToString("yyyy");
            }
            else
            {
                Month = DateTime.Now.ToString("MMMM");
                Year = DateTime.Now.ToString("yyyy");
            }

            StockMain Data = new StockMain();
            string MonthYear = Month + " - " + Year;
            bool IsMainAvailable = _context.StockMains.Any(x => x.MonthYear == MonthYear);
            if (IsMainAvailable)
            {
                Data = _context.StockMains.FirstOrDefault(x => x.MonthYear == MonthYear);
                Data.MonthYear = MonthYear;
                Data.BankDebitAmt = main.BankDebitAmt;
                Data.CreditorAmt = main.CreditorAmt;
                Data.CredTot = main.CredTot;
                Data.Date = DateTime.Now;
                Data.DebitBal70 = main.DebitBal70;
                Data.DebtorAmt = main.DebtorAmt;
                Data.ExcessDB = main.ExcessDB;
                Data.MonthYear = MonthYear;
                Data.StockAmt = main.StockAmt;
                Data.StockDebtTot = main.StockDebtTot;
                _context.StockMains.Update(Data);
                _context.SaveChanges();
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public JsonResult GetStockMainsByMonth(string Date)
        {
            string Month, Year;
            if (Date != null)
            {
                DateTime date = Convert.ToDateTime(Date);
                Month = date.ToString("MMMM");
                Year = date.ToString("yyyy");
            }
            else
            {
                Month = DateTime.Now.ToString("MMMM");
                Year = DateTime.Now.ToString("yyyy");
            }

            StockMain Data = new StockMain();
            string MonthYear = Month + " - " + Year;
            bool IsMainAvailable = _context.StockMains.Any(x => x.MonthYear == MonthYear);
            if (IsMainAvailable)
            {
                Data = _context.StockMains.FirstOrDefault(x => x.MonthYear == MonthYear);
                return Json(Data);
            }
            else
            {
                return Json(false);
            }
        }
        public ActionResult GetMainStock()
        {
            return View(_context.StockMains.ToList());
        }
        public ActionResult GetStockReport(int id)
        {
            return View(GetStockDetails(id));
        }
        public List<StockDetailsVM> GetStockDetails(int id)
        {
            using var connection = _context.Database.GetDbConnection();
            return connection.Query<StockDetailsVM>("StockDetailsSP @smid", new { smid = id }).ToList();
        }
        public ActionResult GetStockMainsReport(int id)
        {
            StockMainVM sm = GetStockMainsReportDetails(id).FirstOrDefault();
            return View(sm);
        }
        public List<StockMainVM> GetStockMainsReportDetails(int id)
        {
            using var connection = _context.Database.GetDbConnection();
            return connection.Query<StockMainVM>("StockMainsSP @smid", new { smid = id }).ToList();
        }
    }
}
