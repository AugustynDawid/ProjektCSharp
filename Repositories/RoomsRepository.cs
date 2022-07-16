using Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Repositories
{
    public class RoomsRepository : BaseRepository
    {
        public RoomsRepository() : base() { }

        public void InsertRoom(Room entity)
        {
            Context.Rooms.Add(entity);
            Context.SaveChanges();
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await Context.Rooms.ToListAsync();
        }

        public void DeleteRoom(int id)
        {
            Room room = new Room();
            room.Id = id;
            Context.Rooms.Attach(room);
            Context.Rooms.Remove(room);
            Context.SaveChanges();
        }
    }
}