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
        }

        public void FindClient(int id)
        {
            Context.Clients.Find(id);
        }

        public async Task<List<Client>> GetAll()
        {
            return await Context.Clients.ToListAsync();
        }
    }
}