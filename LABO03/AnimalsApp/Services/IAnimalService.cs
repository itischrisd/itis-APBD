using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IAnimalService
{
    public IEnumerable<AnimalDTO> GetAnimals(string orderBy);
    public AnimalDTO GetAnimal(int id);
    public int CreateAnimal(AnimalCreationDTO animal);
    public int UpdateAnimal(int id, AnimalUpdateDTO animal);
    public int DeleteAnimal(int id);
}