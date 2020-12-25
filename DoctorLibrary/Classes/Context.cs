using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorLibrary.DAL.Classes
{
    /// <summary>
    ///     Клас для роботи з Npgsql
    /// </summary>
    public class Context : DbContext
    {
        public DbSet<Department> departments { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        /// <summary>
        ///     Підключення до БД
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=95.214.10.36;Port=5432;Database=denysdb;Username=denys;Password=qwerty1*");
        }
    }
}
