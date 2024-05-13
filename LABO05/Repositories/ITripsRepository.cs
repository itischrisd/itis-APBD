using Zadanie7.DTOs;

namespace Zadanie7.Repositories;

public interface ITripsRepository
{
    Task<IEnumerable<TripDto>> GetTripsAsync();
}