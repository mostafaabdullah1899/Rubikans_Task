namespace Task_Rubikans.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public string AreaName { get; set; }
        public List<Item> Items { get; set; }  
    }
}
