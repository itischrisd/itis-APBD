using Zadanie7.DTOs;

namespace Zadanie7.Services;

public interface ITripsService
{
    Task<IEnumerable<TripDto>> GetTripsAsync();
}