using Task_Rubikans.Models;

namespace Task_Rubikans.Repository
{
    public interface IItemTransactionRepository
    {
        List<ItemTransaction> GetAll();
        ItemTransaction GetById(int id);
        int Add(ItemTransaction itemTrans);
        int Update(int id, ItemTransaction newItemTrans);
        int Delete(int id);
    }
}
