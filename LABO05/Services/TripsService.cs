using Zadanie7.DTOs;
using Zadanie7.Repositories;

namespace Zadanie7.Services;

public class TripsService(ITripsRepository tripsRepository) : ITripsService
{
    public async Task<IEnumerable<TripDto>> GetTripsAsync()
    {
        return (await tripsRepository.GetTripsAsync())
            .Select(trip => new TripDto
            {
                Name = trip.Name,
                Description = trip.Description,
                DateFrom = DateOnly.FromDateTime(trip.DateFrom),
                DateTo = DateOnly.FromDateTime(trip.DateTo),
                MaxPeople = trip.MaxPeople,
                Countries = trip.IdCountries.Select(country => new CountryDto
                    {
                        Name = country.Name
                    })
                    .ToList(),
                Clients = trip.ClientTrips.Select(clientTrip => new ClientDto
                    {
                        FirstName = clientTrip.IdClientNavigation.FirstName,
                        LastName = clientTrip.IdClientNavigation.LastName
                    })
                    .ToList()
            });
    }
}