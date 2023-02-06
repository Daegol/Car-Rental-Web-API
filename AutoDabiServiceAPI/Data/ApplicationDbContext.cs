using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AutoDabiServiceAPI.Models;

namespace AutoDabiServiceAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDamage> CarDamages { get; set; }
        public DbSet<CarDamagePart> CarDamageParts { get; set; }
        public DbSet<CarDamageType> CarDamageTypes { get; set; }
        public DbSet<File> Files { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
    }
}
