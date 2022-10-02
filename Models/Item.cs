using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Task_Rubikans.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
        public double Weight { get; set; }
        public double Price { get; set;}
        public double Quantity { get; set; }

        public int InventoryId { get; set; }
        [JsonIgnore]
        public Inventory Inventory { get; set; }

        public List<ItemTransaction> ItemTransactions { get; set; }
    }
}
