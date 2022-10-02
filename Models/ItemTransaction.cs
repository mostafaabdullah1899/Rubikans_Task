namespace Task_Rubikans.Models
{
    public class ItemTransaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double QtyBefore { get; set; }
        public double Quantity { get; set; }
        public double QtyAfter { get; set; }
        public DateTime Date { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
