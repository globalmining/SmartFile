using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models.ViewModels
{
    public class StockMainVM
    {
        public DateTime Date { get; set; }
        public decimal CreditorAmt { get; set; }
        public decimal DebtorAmt { get; set; }
        public decimal TotalAmt { get; set; }
        public decimal TotLesCredAmt { get; set; }
        public decimal Creditor30 { get; set; }
        public decimal Creditor70 { get; set; }
        public decimal RawMaterial { get; set; }
        public decimal FinishedGoods { get; set; }
        public decimal OtherInventory { get; set; }
        public decimal RawMaterial25 { get; set; }
        public decimal RawMaterial75 { get; set; }
        public decimal FinishedGoods25 { get; set; }
        public decimal FinishedGoods75 { get; set; }
        public decimal OtherInventory25 { get; set; }
        public decimal OtherInventory75 { get; set; }
        public decimal TotalAmt25 { get; set; }
        public decimal TotalAmt75 { get; set; }
    }
}
