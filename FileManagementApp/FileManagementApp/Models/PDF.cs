using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models
{
    public class PDF
    {
        public int PDFID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        public int GroupID { get; set; }
        public Group Group { get; set; }
        [Required]
        public int SubGroupID { get; set; }
        public SubGroup SubGroup { get; set; }
        [Required]
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public string PDFName { get; set; }
        [NotMapped]
        public IFormFile PDFFile { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreateON { get; set; }
        [DataType(DataType.Date)]
        public DateTime? UpdateON { get; set; }
    }
}
