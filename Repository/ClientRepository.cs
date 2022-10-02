using Task_Rubikans.Data;
using Task_Rubikans.Models;

namespace Task_Rubikans.Repository
{
    public class ClientRepository: IClientRepository
    {
        DataContext context;
        public ClientRepository(DataContext _context)
        {
            context = _context;
        }
        public List<Client> GetAll()
        {
            return context.Clients.ToList();
        }
        public Client GetById(int id)
        {
            return context.Clients.FirstOrDefault(c => c.Id == id);
        }
        public Client GetId()
        {
            return context.Clients.FirstOrDefault();
        }
        public int Add(Client newClient)
        {
            context.Clients.Add(newClient);
            return context.SaveChanges();
        }
        public int Update(int id ,Client newClient)
        {
            Client oldClient = GetById(id);
            oldClient.Name=newClient.Name;
            oldClient.Mobile=newClient.Mobile;
            oldClient.Address=newClient.Address;
            oldClient.Email=newClient.Email;
            oldClient.Balance = newClient.Balance;
            return context.SaveChanges();
        }
        public int Delete(int id)
        {
            Client client = GetById(id);
            context.Clients.Remove(client);
            return context.SaveChanges();
        }

       
    }

    
}
