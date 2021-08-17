using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models
{
    public class StockMain
    {
        [Key]
        public int StockMainID { get; set; }
        [Required]
        public string MonthYear { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal StockAmt { get; set; }
        [Required]
        public decimal DebtorAmt { get; set; }
        [Required]
        public decimal StockDebtTot { get; set; }
        [Required]
        public decimal CreditorAmt { get; set; }
        [Required]
        public decimal CredTot { get; set; }
        [Required]
        public decimal DebitBal70 { get; set; }
        [Required]
        public decimal BankDebitAmt { get; set; }
        [Required]
        public decimal ExcessDB { get; set; }
    }
}
