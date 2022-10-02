using Task_Rubikans.Models;

namespace Task_Rubikans.Repository
{
    public interface IClientRepository
    {
        List<Client> GetAll();
        Client GetById(int id);
        Client GetId();
        int Add(Client client);
        int Update(int id, Client newClient);
        int Delete(int id);
    }
}