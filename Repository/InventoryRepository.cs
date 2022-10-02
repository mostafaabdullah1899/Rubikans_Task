using Task_Rubikans.Data;
using Task_Rubikans.Models;

namespace Task_Rubikans.Repository
{
    public class InventoryRepository: IInventoryRepository
    {

        DataContext context;
        public InventoryRepository(DataContext _context)
        {
            context = _context;
        }
        public List<Inventory> GetAll()
        {
            return context.Inventories.ToList();
        }
        public Inventory GetById(int id)
        {
            return context.Inventories.FirstOrDefault(c => c.Id == id);
        }
        public Inventory GetId()
        {
            return context.Inventories.FirstOrDefault();
        }
        public int Add(Inventory newInventory)
        {
            context.Inventories.Add(newInventory);
            return context.SaveChanges();
        }
        public int Update(int id, Inventory newInventory)
        {
            Inventory oldInventory = GetById(id);
            oldInventory.Name = newInventory.Name;
            oldInventory.ManagerName = newInventory.ManagerName;
            oldInventory.AreaName = newInventory.AreaName;
           
            return context.SaveChanges();
        }
        public int Delete(int id)
        {
            Inventory Inventory = GetById(id);
            context.Inventories.Remove(Inventory);
            return context.SaveChanges();
        }

    }
}
