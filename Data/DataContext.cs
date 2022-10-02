using Microsoft.EntityFrameworkCore;
using Task_Rubikans.Models;

namespace Task_Rubikans.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }
        public DbSet<SaleInvoice> SaleInvoices { get; set; }
        public DbSet<SaleInvoiceDetail> SaleInvoiceDetails { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemTransaction> ItemTransactions { get; set; }

    }
}
