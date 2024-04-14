using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals();
    Animal GetAnimal(int id);
    int CreateAnimal(Animal animal);
    int DeleteAnimal(int id);
    int UpdateAnimal(Animal animal);
}