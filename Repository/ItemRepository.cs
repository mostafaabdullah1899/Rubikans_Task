using Microsoft.EntityFrameworkCore;
using Task_Rubikans.Data;
using Task_Rubikans.Models;

namespace Task_Rubikans.Repository
{
    public class ItemRepository: IItemRepository
    {
        DataContext context;
        public ItemRepository(DataContext _context)
        {
            context = _context;
        }
        public List<Item> GetAll()
        {
            return context.Items.Include(i=>i.Inventory).ToList();
        }
        public Item GetById(int id)
        {
            return context.Items.Include(i => i.Inventory).FirstOrDefault(c => c.Id == id);
        }
        public int Add(Item newItem)
        {
            context.Items.Add(newItem);
            return context.SaveChanges();
        }
        public int Update(int id, Item newItem)
        {
            Item oldItem = GetById(id);
            oldItem.Name = newItem.Name;
            oldItem.UnitName = newItem.UnitName;
            oldItem.Weight = newItem.Weight;
            oldItem.Price = newItem.Price;
            oldItem.Quantity = newItem.Quantity;
            oldItem.InventoryId = newItem.InventoryId;
            return context.SaveChanges();
        }
        public int Delete(int id)
        {
            Item Item = GetById(id);
            context.Items.Remove(Item);
            return context.SaveChanges();
        }
    }
}
