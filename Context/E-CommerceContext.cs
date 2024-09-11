using Microsoft.EntityFrameworkCore;
using ITI_Final_Project.Models;
namespace ITI_Final_Project.Context
{
    public class E_CommerceContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ITI-E-Commerce;Trusted_Connection=True;Encrypt=false");
        }
        /*---------------------------------------------------------*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*-----------------------------------------------------*/
            // Seading
            var _Categories = new List<Category>
            {
                new Category { Id = 1, Name = "Phones" },
                new Category { Id = 2, Name = "Laptop" },
                new Category { Id = 3, Name = "Fruits" },
                
            };
            /*-----------------------------------------------------*/
            var _Users = new List<User>
            {
                new User { Id = 1, FName = "Ramy", LName = "Mai" , Email = "email@mail.com", Password = "123456" },
                new User { Id = 2, FName = "Mai", LName = "Ali",   Email = "email@mail.com", Password = "123456"},
                new User { Id = 3, FName = "Ali", LName = "Ramy",   Email = "email@mail.com", Password = "123456" },
                new User { Id = 4, FName = "Omar", LName = "Ramy",   Email = "email@mail.com", Password = "123456" },
                new User { Id = 5, FName = "Mostafa", LName = "Omar",   Email = "email@mail.com", Password = "123456"  },
                new User { Id = 6, FName = "Ahmed", LName = "Mostafa",   Email = "email@mail.com", Password = "123456" },
                new User { Id = 7, FName = "Sara", LName = "Ahmed",   Email = "email@mail.com", Password = "123456" },
                new User { Id = 8, FName = "Osama", LName = "Mohamed",   Email = "email@mail.com", Password = "123456" },
                new User { Id = 9, FName = "Mohamed", LName = "Osama",   Email = "email@mail.com", Password = "123456"},
                new User { Id = 10, FName = "Nour", LName = "Nour",   Email = "email@mail.com", Password = "123456" },
                new User { Id = 11, FName = "Mohamed", LName = "Nour",   Email = "email@mail.com", Password = "123456" },
                new User { Id = 12, FName = "Nour", LName = "Ramy",   Email = "email@mail.com", Password = "123456" }
            };

            var _Product = new List<Product>
            {
                new Product { Id = 1, Title = "IPhone 12", Price = 2234, Quantity=2 , CategoryId = 1 },
                 new Product { Id = 2, Title = "Lenovo Legion2", Price = 2234, Quantity=2 , CategoryId = 2 },
                new Product { Id = 3, Title = "Samsung galaxy 123", Price = 3234, Quantity=2 , CategoryId = 1 },
                new Product { Id = 4, Title = "Huawei y4", Price = 4234, Quantity=2 , CategoryId = 1 },
                new Product { Id = 5, Title = "HP victus21", Price = 5234, Quantity=2 , CategoryId = 2 },
                new Product { Id = 6, Title = "Oppo v13", Price = 6234, Quantity=2 , CategoryId = 1 },
               
            };
            /*-----------------------------------------------------*/
            modelBuilder.Entity<Product>().HasData(_Product);
            modelBuilder.Entity<Category>().HasData(_Categories);
            modelBuilder.Entity<User>().HasData(_Users);
            /*-----------------------------------------------------*/
        }
        /*---------------------------------------------------------*/
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users{ get; set; }

        public virtual DbSet<Product> Products { get; set; }
        /*---------------------------------------------------------*/
    }
}

