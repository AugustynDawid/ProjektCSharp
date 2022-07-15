using Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Repositories
{
    public class ClientsRepository : BaseRepository
    {
        public ClientsRepository(ApplicationDbContext AppContext) : base(AppContext) { }

        public void InsertUser(Client entity)
        {
            Context.Clients.Add(entity);
        }

        public void FindUser(int id)
        {
            Context.Clients.Find(id);
        }

        public async Task<List<Client>> GetAll()
        {
            return await Context.Clients.ToListAsync();
        }
    }
}