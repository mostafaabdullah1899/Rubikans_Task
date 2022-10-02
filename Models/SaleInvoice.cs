namespace Task_Rubikans.Models
{
    public class SaleInvoice
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        public int InventorId { get; set; }
        public double TotalQty { get; set; }
        public double TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public List<SaleInvoiceDetail> SaleInvoiceDetails { get; set; }
    }
}
