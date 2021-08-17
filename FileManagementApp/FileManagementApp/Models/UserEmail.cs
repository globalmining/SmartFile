using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models
{
    public class UserEmail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Emailid { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
