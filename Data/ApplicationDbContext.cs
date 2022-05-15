using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Shopping.Models;

namespace Shopping.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Matrial>()
                .HasMany<MaterialItem>(i => i.Item)
                .WithOne(m => m.Matrial)
                .HasForeignKey(m => m.MatrialID)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Shopping.Models.Matrial> Matrial { get; set; }
        public DbSet<Shopping.Models.MaterialItem> MaterialItem { get; set; }
    }
}
