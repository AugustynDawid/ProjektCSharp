using Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Repositories
{
    public class ReservationsRepository : BaseRepository
    {
        public ReservationsRepository() : base() { }

        public void InsertReservation(Reservation entity)
        {
            Context.Reservations.Add(entity);
            Context.SaveChanges();
        }

        public async Task<List<Reservation>> GetAllReservations()
        {
            return await Context.Reservations.ToListAsync();
        }
    }
}