using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; }
        [Required]
        public int GroupID { get; set; }
        public Group Group { get; set; }
        [Required]
        public int SubGroupID { get; set; }
        public SubGroup SubGroup { get; set; }
    }
}
