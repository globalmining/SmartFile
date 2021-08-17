using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        [Required]
        [StringLength(30)]
        public string GroupName { get; set; }

        public ICollection<SubGroup> SubGroups { get; set; }
    }
}
