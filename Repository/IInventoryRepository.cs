using Task_Rubikans.Models;

namespace Task_Rubikans.Repository
{
    public interface IInventoryRepository
    {

        List<Inventory> GetAll();
        Inventory GetById(int id);
        Inventory GetId();
        int Add(Inventory inventory);
        int Update(int id, Inventory newInventory);
        int Delete(int id);
    }
}