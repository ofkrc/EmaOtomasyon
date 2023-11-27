﻿using EmaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmaAPI.Context
{
    public class EmaDbContext : DbContext
    {
        public EmaDbContext(DbContextOptions<EmaDbContext> options) : base(options)
        {
        }

        public DbSet<Company>? Companies { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Invoice>? Invoices { get; set; }

    }

}


