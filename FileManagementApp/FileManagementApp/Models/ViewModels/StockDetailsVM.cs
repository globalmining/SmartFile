using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models.ViewModels
{
    public class StockDetailsVM
    {
        public string Date { get; set; }
        public string Month_Year { get; set; }
        public decimal StockAmt { get; set; }
        public string ItemName { get; set; }
        public decimal LastBalOty { get; set; }
        public decimal PurchaseQty { get; set; }
        public decimal SaleQty { get; set; }
        public decimal StockQty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public string Unit { get; set; }
    }
}
