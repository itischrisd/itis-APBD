﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController(IAnimalService animalService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals(string orderBy = "Name")
    {
        return Ok(animalService.GetAnimals(orderBy));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = animalService.GetAnimal(id);

        if (animal == null) return NotFound("Animal not found");

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(AnimalCreationDTO animal)
    {
        var id = animalService.CreateAnimal(animal);
        return CreatedAtAction(nameof(CreateAnimal), id);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, AnimalUpdateDTO animalUpdated)
    {
        var animal = animalService.GetAnimal(id);

        if (animal == null) return NotFound("Animal not found");

        _ = animalService.UpdateAnimal(id, animalUpdated);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = animalService.GetAnimal(id);

        if (animal == null) return NotFound("Animal not found");

        _ = animalService.DeleteAnimal(id);

        return NoContent();
    }
}