using Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Repositories
{
    public class ClientsRepository : BaseRepository
    {
        public ClientsRepository() : base() { }

        public void InsertClient(Client entity)
        {
            Context.Clients.Add(entity);
            Context.SaveChanges();
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await Context.Clients.ToListAsync();
        }

        public void DeleteClient(int id)
        {
            Client client = new Client();
            client.Id = id;
            Context.Clients.Attach(client);
            Context.Clients.Remove(client);
            Context.SaveChanges();
        }
    }
}