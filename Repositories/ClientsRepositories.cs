using Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ClientsRepository
    {
        private DbSet<Client> Ctx;

        public ClientsRepository(ApplicationDbContext AppContext)
        {
            this.Ctx = AppContext.Clients;
        }

        public void InsertUser(Client entity)
        {
            Ctx.Add(entity);
        }

        public void FindUser(int id)
        {
            Ctx.Find(id);
        }
    }
}