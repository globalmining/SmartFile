using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Models
{
    public class ApplicationUser: IdentityUser
    {
        public int MineID { get; set; }
        public Mine Mine { get; set; }
    }
}
