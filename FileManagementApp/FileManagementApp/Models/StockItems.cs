using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models
{
    public class StockItems
    {
        [Key]
        public int ItemID { get; set; }
        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; }
        [Required]
        public string ItemGroup { get; set; }
        [Required]
        public string Unit { get; set; }
    }
}
