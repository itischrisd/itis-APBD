using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace AnimalsAppTest.TestDoubles;

public class FakeAnimalReposiotry : IAnimalRepository
{
    private IEnumerable<Animal> _animals = new List<Animal>
    {
        new() { Id = 1, Name = "Lion", Description = "The king of the jungle", Category = "Mammal", Area = "Africa" },
        new() { Id = 2, Name = "Elephant", Description = "Large land animal", Category = "Mammal", Area = "Asia" },
        new() { Id = 3, Name = "Penguin", Description = "A flightless bird", Category = "Bird", Area = "Antarctica" }
    };

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return orderBy.ToLower() switch
        {
            "id" => _animals.OrderBy(a => a.Id),
            "category" => _animals.OrderBy(a => a.Category),
            "description" => _animals.OrderBy(a => a.Description),
            "area" => _animals.OrderBy(a => a.Area),
            _ => _animals.OrderBy(a => a.Name)
        };
    }

    public Animal GetAnimal(int id)
    {
        return _animals.FirstOrDefault(a => a.Id == id)!;
    }

    public int CreateAnimal(Animal animal)
    {
        _animals = _animals.Append(new Animal
        {
            Id = _animals.Max(a => a.Id) + 1,
            Name = animal.Name,
            Description = animal.Description,
            Category = animal.Category,
            Area = animal.Area
        });
        return _animals.Max(a => a.Id);
    }

    public int UpdateAnimal(Animal animal)
    {
        var animalToUpdate = _animals.FirstOrDefault(a => a.Id == animal.Id);
        if (animalToUpdate == null) return 0;

        _animals = _animals.Select(a => a.Id == animal.Id ? animal : a);
        return 1;
    }

    public int DeleteAnimal(int id)
    {
        var animalToDelete = _animals.FirstOrDefault(a => a.Id == id);
        if (animalToDelete == null) return 0;

        _animals = _animals.Where(a => a.Id != id);
        return 1;
    }
}