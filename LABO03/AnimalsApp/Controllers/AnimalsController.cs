using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController(IConfiguration configuration, IAnimalService animalService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<AnimalDTO>> GetAnimals()
    {
        using var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        using var com = new SqlCommand();

        com.CommandText = "SELECT * FROM Animals";

        con.Open();

        var reader = com.ExecuteReader();
        var animals = new List<Animal>();
        while (reader.Read())
        {
            var animal = new Animal
            {
                Id = (int)reader["id"],
                Name = (string)reader["name"],
                Description = (string)reader["description"],
                Category = (string)reader["category"],
                Area = (string)reader["area"]
            };

            animals.Add(animal);
        }

        return Ok(animals);
    }

    [HttpPost]
    public ActionResult CreateAnimal(AnimalCreationDTO animal)
    {
        using var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        using var com = new SqlCommand();

        com.CommandText = "INSERT INTO Animals (Name, Description, Category, Area) VALUES (@name, @description, @category, @area); SELECT SCOPE_IDENTITY();";
        com.Parameters.AddWithValue("@name", animal.Name);
        com.Parameters.AddWithValue("@description", animal.Description);
        com.Parameters.AddWithValue("@category", animal.Category);
        com.Parameters.AddWithValue("@area", animal.Area);

        con.Open();

        var affectedCount = (int)com.ExecuteScalar();

        return Created();
    }
}