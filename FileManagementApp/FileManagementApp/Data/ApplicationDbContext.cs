using FileManagementApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<Mine> Mines { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<SubGroup> SubGroups { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PdfFile> PdfFiles { get; set; }
        //public DbSet<FileManagementApp.Models.Email> Email { get; set; }
        public DbSet<PDF> PDFs { get; set; }
        public DbSet<UserEmail> UserEmail { get; set; }
        public DbSet<SentEmailList> SentEmailList { get; set; }
        public DbSet<StockItems> StockItems { get; set; }
        public DbSet<StockMain> StockMains { get; set; }
        public DbSet<StockDetails> StockDetails { get; set; }
    }
}
