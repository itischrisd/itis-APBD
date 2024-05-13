using Microsoft.EntityFrameworkCore;
using Zadanie7.Context;
using Zadanie7.Models;

namespace Zadanie7.Repositories;

public class TripsRepository(ApbdContext context) : ITripsRepository
{
    public async Task<IEnumerable<Trip>> GetTripsAsync()
    {
        return await context.Trips
            .Include(trip => trip.IdCountries)
            .Include(trip => trip.ClientTrips)
            .ThenInclude(clientTrip => clientTrip.IdClientNavigation)
            .OrderByDescending(trip => trip.DateFrom)
            .ToListAsync();
    }
}