using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models
{
    [Keyless]
    public class Email
    {
        
        public int PdfFileID { get; set; }
        public string[] To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string PdfFileUrl { get; set; }
        public string PdfFileName { get; set; }
        //[NotMapped]
        //public IFormFile Attachmentpdf { get; set; }
    }
}
