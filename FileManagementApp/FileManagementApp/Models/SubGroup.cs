﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models
{
    public class SubGroup
    {
        public int SubGroupID { get; set; }
        [Required]
        [StringLength(50)]
        public string SubGroupName { get; set; }
        public int GroupID { get; set; }
        public Group Group { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
