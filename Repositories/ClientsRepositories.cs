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
    }
}