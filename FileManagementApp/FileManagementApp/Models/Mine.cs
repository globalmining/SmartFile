using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models
{
    public class Mine
    {
        public int MineID { get; set; }
        [Required]
        [StringLength(50)]
        public string MineName { get; set; }
    }
}
