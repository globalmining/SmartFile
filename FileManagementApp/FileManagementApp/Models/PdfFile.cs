using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models
{
    public class PdfFile
    {
        public int PdfFileID { get; set; }
        [Required]
        [MaxLength(200)]
        public string PdfFileName { get; set; }
        [Required]
        public int GroupID { get; set; }
        public Group Group { get; set; }
        [Required]
        public int SubGroupID { get; set; }
        public SubGroup SubGroup { get; set; }
        [Required]
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public string PdfFileUrl { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreateON { get; set; }
        [DataType(DataType.Date)]
        public DateTime? UpdateON { get; set; }
    }
}
