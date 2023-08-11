using InsuranceAPIApplication.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.Context
{
    public class InsuranceDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<InsuranceCategory> InsuranceCategories { get; set; }
        public DbSet<InsuranceCategoryPackage> InsuranceCategoryPackages { get; set; }
        public DbSet<InsuranceCategoryPackageLink> InsuranceCategoryPackageLinks { get; set; }
        public DbSet<InsuranceClaim> InsuranceClaims { get; set; }
        public DbSet<InsuranceInvoice> InsuranceInvoices { get; set; }
        public DbSet<InsuranceInvoiceClaimLink> InsuranceInvoiceClaimLinks { get; set; }
        public DbSet<UserDTO> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}