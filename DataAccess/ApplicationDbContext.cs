using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DigitalRegistry.Models;

namespace DigitalRegistry.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<All_Social_Media> All_Social_Media { get; set; }
        public DbSet<Social_Media> Social_Media { get; set; }
        public DbSet<Agencies> Agencies { get; set; }
        public DbSet<Tags> Tags { get; set; }
    }
}
