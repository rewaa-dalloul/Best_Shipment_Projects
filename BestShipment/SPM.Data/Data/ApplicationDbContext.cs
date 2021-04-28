using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPM.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPM.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<SupplierEntity> Suppliers { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<UnitEntity> Units { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<BranchEntity> Branches { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductSupplierEntity> ProductSuppliers { get; set; }
        public DbSet<PurchaseOrderEntity> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItemEntity> PurchaseOrderItems { get; set; }
        public DbSet<RFQEntity> RFQs { get; set; }
        public DbSet<RFQItemEntity> RFQItems { get; set; }
        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<InvoiceItemEntity> InvoiceItems { get; set; }
    }
}
