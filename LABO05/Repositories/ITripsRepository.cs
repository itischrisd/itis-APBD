using Zadanie7.DTOs;
using Zadanie7.Models;

namespace Zadanie7.Repositories;

public interface ITripsRepository
{
    Task<IEnumerable<Trip>> GetTripsAsync();
}