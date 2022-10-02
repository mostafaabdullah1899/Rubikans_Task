using Task_Rubikans.Models;

namespace Task_Rubikans.ViewModel
{
    public class InvoiceVM
    {
        public int ClientId { get; set; }   
        public int InventoryId { get; set; }
        public virtual List<Item> Items { get; set; }

    }
}
