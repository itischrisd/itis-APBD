using Microsoft.EntityFrameworkCore;
using Zadanie7.Context;
using Zadanie7.DTOs;

namespace Zadanie7.Repositories;

public class TripsRepository(ApbdContext context) : ITripsRepository
{
    public async Task<IEnumerable<TripDto>> GetTripsAsync()
    {
        var result = await context
            .Trips
            .Select(e =>
                new TripDto
                {
                    Name = e.Name,
                    Description = e.Description,
                    DateFrom = DateOnly.FromDateTime(e.DateFrom),
                    DateTo = DateOnly.FromDateTime(e.DateTo),
                    MaxPeople = e.MaxPeople,
                    Countries = e.IdCountries.Select(c => new CountryDto
                    {
                        Name = c.Name
                    }),
                    Clients = e.ClientTrips.Select(ct => new ClientDto
                    {
                        FirstName = ct.IdClientNavigation.FirstName,
                        LastName = ct.IdClientNavigation.LastName
                    })
                }).ToListAsync();
        if (result.Count == 0) throw new Exception("No trips found");
        return result;
    }
}