using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace mp_test.DAL
{
    public class MPContext : DbContext
    {
        public MPContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Executor> Executor { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderTracking> OrderTracking { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<PackageType> PackageType { get; set; }
        public DbSet<PackageCathegory> PackageCathegory { get; set; }
        public DbSet<PaymentTracking> PaymentTracking { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<ServiceStatus> ServiceStatus { get; set; }
        public DbSet<ServiceTracking> ServiceTracking { get; set; }
        public DbSet<ServiceType> ServiceType { get; set; }
        public DbSet<ServiceCathegory> ServiceCathegory { get;set; }
    }
}