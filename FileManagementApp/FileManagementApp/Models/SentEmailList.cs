using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models
{
    public class SentEmailList
    {
        [Key]
        public int Id { get; set; }
        public string Emailid { get; set; }
        public string Filename { get; set; }
        public DateTime SentDateTime { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
