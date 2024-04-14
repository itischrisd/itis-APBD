using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class AnimalService(IAnimalRepository animalRepository) : IAnimalService
{
    
}