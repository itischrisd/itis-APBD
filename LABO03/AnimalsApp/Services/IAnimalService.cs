﻿using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IAnimalService
{
    public IEnumerable<AnimalDto> GetAnimals(string orderBy);
    public AnimalDto GetAnimal(int id);
    public int CreateAnimal(AnimalCreationDto animal);
    public int UpdateAnimal(int id, AnimalUpdateDto animal);
    public int DeleteAnimal(int id);
}