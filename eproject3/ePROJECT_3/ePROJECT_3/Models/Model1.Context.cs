﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ePROJECT_3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NexusmarketingEntities : DbContext
    {
        public NexusmarketingEntities()
            : base("name=NexusmarketingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Emplooyee> Emplooyees { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<ojbect> ojbects { get; set; }
        public virtual DbSet<Order_details> Order_details { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pay> Pays { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductServy> ProductServies { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
    }
}
