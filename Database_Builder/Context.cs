using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Builder;
using Microsoft.EntityFrameworkCore;

namespace Database_Builder
{
    public class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string connectionString = @"
                    Data Source=DESKTOP-GSQML5J\MYSERVER;
                    Initial Catalog=TheShop;
                    Integrated Security=True;
                    Connect Timeout=30;
                    Encrypt=False;
                    TrustServerCertificate=False;
                    ApplicationIntent=ReadWrite;
                    MultiSubnetFailover=False";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            /*
             * <Client's configuration>
             */
            mb.Entity<Client>().HasKey(x => x.ClientID);

            mb.Entity<Client>().Property(x => x.ClientID)
                .UseIdentityColumn(1, 1)
                .HasColumnType("int")
                .IsRequired();

            //Client's details
            mb.Entity<Client>().Property(x => x.FirstName)
                .HasColumnType("varchar(255)")
                .IsRequired();

            mb.Entity<Client>().Property(x => x.SecondName)
                .HasColumnType("varchar(255)")
                .IsRequired();

            mb.Entity<Client>().Property(x => x.CompanyName)
                .HasColumnType("varchar(255)");

            mb.Entity<Client>().Property(x => x.Email)
                .HasColumnType("varchar(255)")
                .IsRequired();

            mb.Entity<Client>().Property(x => x.PhoneNumber)
                .HasColumnType("varchar(15)")
                .IsRequired();

            //client's address
            mb.Entity<Client>().Property(x => x.Country)
                .HasColumnType("varchar(255)")
                .IsRequired();

            mb.Entity<Client>().Property(x => x.City)
                .HasColumnType("varchar(255)")
                .IsRequired();

            mb.Entity<Client>().Property(x => x.Street)
                .HasColumnType("varchar(255)")
                .IsRequired();

            mb.Entity<Client>().Property(x => x.Postcode)
                .HasColumnType("varchar(255)")
                .IsRequired();

            mb.Entity<Client>().Property(x => x.BuildingNumber)
                .HasColumnType("varchar(20)")
                .IsRequired();

            //account details - It's entirely unsafe to keep them here

            mb.Entity<Client>().Property(x => x.Username)
                .HasColumnType("varchar(255)")
                .IsRequired();

            mb.Entity<Client>().Property(x => x.Password)
                .HasColumnType("varchar(255)")
                .IsRequired();

            mb.Entity<Client>().Property(x => x.IsAdmin)
                .HasColumnType("bit")
                .IsRequired();

            /*
             * <End of Clients configuration>
             */

            



            /*
             * <Orders configuration> 
             */
            //Primary Key
            mb.Entity<Order>().HasKey(x => x.OrderID);

            mb.Entity<Order>().Property(x => x.OrderID)
                .HasColumnType("int")
                .UseIdentityColumn(1, 1)
                .IsRequired();

            //Details
            mb.Entity<Order>().Property(x => x.CustomerID)
                .IsRequired();

            mb.Entity<Order>().Property(x => x.ReceivedDate)
                .HasColumnType("datetime")
                .IsRequired();

            mb.Entity<Order>().Property(x => x.SentDate)
                .HasColumnType("datetime");


            mb.Entity<Order>().Property(x => x.DeliveredDate)
                .HasColumnType("datetime");

            mb.Entity<Order>().Property(x => x.IsPlaced)
                .HasColumnType("bit")
                .IsRequired();

            /*
             * <End of Orders configuration>
             */



            /*
             * <OrderDetails configuration>
             */

            mb.Entity<OrderDetail>().HasNoKey();

            mb.Entity<OrderDetail>().Property(x => x.OrderID)
                .HasColumnType("int")
                .IsRequired();

            mb.Entity<OrderDetail>().Property(x => x.ProductID)
                .HasColumnType("int")
                .IsRequired();

            mb.Entity<OrderDetail>().Property(x => x.Price)
                .HasColumnType("money")
                .IsRequired();

            mb.Entity<OrderDetail>().Property(x => x.Quantity)
                .HasColumnType("int")
                .IsRequired();
            /*
             * <End of OrderDetails configuration>
             */



            /*
             * <Product configuration>
             */
            //Primary Key 
            mb.Entity<Product>().HasKey(x => x.ProductID);

            mb.Entity<Product>().Property(x => x.ProductID)
                .UseIdentityColumn(1, 1)
                .HasColumnType("int")
                .IsRequired();

            //Car details
            mb.Entity<Product>().Property(x => x.CarBrand)
                .IsRequired();

            mb.Entity<Product>().Property(x => x.CarModel)
                .IsRequired();

            mb.Entity<Product>().Property(x => x.CarFirstProdYear)
                .IsRequired();

            mb.Entity<Product>().Property(x => x.CarLastProdYear)
                .IsRequired();

            //Price
            mb.Entity<Product>().Property(x => x.Price)
                .HasColumnType("money")
                .HasColumnName("Price")
                .IsRequired();

            //Product details
            mb.Entity<Product>().Property(x => x.PartName)
                .HasColumnType("varchar(255)")
                .HasColumnName("Name")
                .IsRequired();

            mb.Entity<Product>().Property(x => x.PartCategory)
                .HasColumnType("varchar(50)")
                .HasColumnName("Category")
                .IsRequired();

            mb.Entity<Product>().Property(x => x.PartManufacturer)
                .HasColumnType("varchar(255)")
                .HasColumnName("Manufacturer")
                .IsRequired();

            mb.Entity<Product>().Property(x => x.PartCode)
                .HasColumnType("varchar(36)")
                .HasColumnName("Code")
                .IsRequired();

            mb.Entity<Product>().Property(x => x.IsAvailable)
                .IsRequired();

            mb.Entity<Product>().Property(x => x.QtAvailable)
                .HasColumnName("Quantity")
                .HasColumnType("int");
            /*
             * <End of Product configuration>
             */

        }
    }
}

