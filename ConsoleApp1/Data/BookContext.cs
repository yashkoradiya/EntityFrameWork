
    using System;
    using System.Collections.Generic;
    using ConsoleApp1.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    //using System.Data.Entity;

    namespace ConsoleApp1.Models
    {
        public partial class BookContext : DbContext
        {
           

            public BookContext()
            {
            }

            public BookContext(DbContextOptions<BookContext> options)
                : base(options)
            {
            }
        //public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("Server=68L3RG2-SHEL\\SQLEXPRESS;Database=Training;Trusted_Connection=True;MultipleActiveResultSets=True");
                }
            }

            //protected override void OnModelCreating(ModelBuilder modelBuilder)
            //{

            //    modelBuilder.Entity<Book>()
            //      .Property(b => b.price)
            //      .IsRequired() //Required
            //      .HasColumnName("BKPrice")
            //      .HasDefaultValue(200);


            //}
        }
    }

