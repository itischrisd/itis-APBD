using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class AnimalService(IAnimalRepository animalRepository) : IAnimalService
{
    public IEnumerable<AnimalDTO> GetAnimals(string orderBy)
    {
        return animalRepository.GetAnimals(orderBy)
            .Select(a => new AnimalDTO
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Category = a.Category,
                Area = a.Area
            });
    }

    public AnimalDTO GetAnimal(int id)
    {
        var animal = animalRepository.GetAnimal(id);

        if (animal == null) return null!;

        return new AnimalDTO
        {
            Id = animal.Id,
            Name = animal.Name,
            Description = animal.Description,
            Category = animal.Category,
            Area = animal.Area
        };
    }

    public int CreateAnimal(AnimalCreationDTO animal)
    {
        return animalRepository.CreateAnimal(new Animal
        {
            Name = animal.Name,
            Description = animal.Description,
            Category = animal.Category,
            Area = animal.Area
        });
    }

    public int UpdateAnimal(int id, AnimalUpdateDTO animal)
    {
        return animalRepository.UpdateAnimal(new Animal
        {
            Id = id,
            Name = animal.Name,
            Description = animal.Description,
            Category = animal.Category,
            Area = animal.Area
        });
    }

    public int DeleteAnimal(int id)
    {
        return animalRepository.DeleteAnimal(id);
    }
}