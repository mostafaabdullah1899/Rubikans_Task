using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Task_Rubikans.Models
{
    public class SaleInvoiceDetail
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemId { get; set; }
        public double Qty { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        [ForeignKey("SaleInvoice")]
        public int SaleInvoiceId { get; set; }
        [JsonIgnore]
        public SaleInvoice SaleInvoice { get; set; }
    }
}
