using Task_Rubikans.Models;

namespace Task_Rubikans.Repository
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        Item GetById(int id);
        int Add(Item item);
        int Update(int id, Item newItem);
        int Delete(int id);
    }
}
