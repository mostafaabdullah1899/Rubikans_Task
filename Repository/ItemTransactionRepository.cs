using Microsoft.EntityFrameworkCore;
using System.Linq;
using Task_Rubikans.Data;
using Task_Rubikans.Models;

namespace Task_Rubikans.Repository
{
    public class ItemTransactionRepository: IItemTransactionRepository
    {
        DataContext context;
        public ItemTransactionRepository(DataContext _context)
        {
            context = _context;
        }
        public List<ItemTransaction> GetAll()
        {
            return context.ItemTransactions.Include(i => i.Item).ToList();
        }
        public ItemTransaction GetById(int id)
        {
            return context.ItemTransactions.Include(i => i.Item).FirstOrDefault(d=>d.Id==id);
        }
        public int Add(ItemTransaction newItemTrans)
        {
            context.ItemTransactions.Add(newItemTrans);
            return context.SaveChanges();
        }
        public int Update(int id, ItemTransaction newItemTrans)
        {
            ItemTransaction oldItemTrans = GetById(id);
            oldItemTrans.Name = newItemTrans.Name;
            oldItemTrans.Quantity = newItemTrans.Quantity;
            oldItemTrans.QtyBefore= newItemTrans.QtyBefore;
            oldItemTrans.QtyAfter= newItemTrans.QtyAfter;
            return context.SaveChanges();
        }
        public int Delete(int id)
        {
            ItemTransaction itemstrans = GetById(id);
            context.ItemTransactions.Remove(itemstrans);
            return context.SaveChanges();
        }

        
    }
}
