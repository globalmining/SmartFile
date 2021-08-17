using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models
{
    public class StockDetails
    {
        [Key]
        public int StockDetailID { get; set; }
        public int StockMainID { get; set; }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string GroupName { get; set; }
        public string Unit { get;set; }
        public decimal LastBalQty { get; set; }
        public decimal PurchaseQty { get; set; }
        public decimal SaleQty { get; set; }
        public decimal StockQty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
