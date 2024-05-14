using System.Linq;
using AnimalsAppTest.TestDoubles;
using JetBrains.Annotations;
using WebApplication1.DTOs;
using WebApplication1.Services;
using Xunit;

namespace AnimalsAppTest;

[TestSubject(typeof(AnimalService))]
public class AnimalServiceTest
{
    [Fact]
    public void GetAnimals_Should_Return_Animals_Sorted_By_Name()
    {
        var animalRepository = new FakeAnimalReposiotry();
        var animalService = new AnimalService(animalRepository);

        animalService.GetAnimals("name");

        Assert.Equal("Elephant", animalService.GetAnimals("name")
            .First()
            .Name);
        Assert.Equal("Lion", animalService.GetAnimals("name")
            .ElementAt(1)
            .Name);
        Assert.Equal("Penguin", animalService.GetAnimals("name")
            .Last()
            .Name);
        Assert.Equal(3, animalService.GetAnimals("name")
            .Count());
    }

    [Fact]
    public void GetAnimals_Should_Return_Animals_Sorted_By_Id()
    {
        var animalRepository = new FakeAnimalReposiotry();
        var animalService = new AnimalService(animalRepository);

        animalService.GetAnimals("id");

        Assert.Equal("Lion", animalService.GetAnimals("id")
            .First()
            .Name);
        Assert.Equal("Elephant", animalService.GetAnimals("id")
            .ElementAt(1)
            .Name);
        Assert.Equal("Penguin", animalService.GetAnimals("id")
            .Last()
            .Name);
        Assert.Equal(3, animalService.GetAnimals("id")
            .Count());
    }

    [Fact]
    public void GetAnimal_Should_Return_Animal_With_Correct_Id()
    {
        var animalRepository = new FakeAnimalReposiotry();
        var animalService = new AnimalService(animalRepository);

        var animal = animalService.GetAnimal(2);

        Assert.Equal(2, animal.Id);
        Assert.Equal("Elephant", animal.Name);
        Assert.Equal("Large land animal", animal.Description);
        Assert.Equal("Mammal", animal.Category);
        Assert.Equal("Asia", animal.Area);
    }

    [Fact]
    public void GetAnimal_Should_Return_Null_When_Animal_Not_Found()
    {
        var animalRepository = new FakeAnimalReposiotry();
        var animalService = new AnimalService(animalRepository);

        var animal = animalService.GetAnimal(4);

        Assert.Null(animal);
    }

    [Fact]
    public void CreateAnimal_Should_Return_Created_Animal_Id()
    {
        var animalRepository = new FakeAnimalReposiotry();
        var animalService = new AnimalService(animalRepository);

        var id = animalService.CreateAnimal(new AnimalCreationDTO
        {
            Name = "Tiger",
            Description = "Large cat",
            Category = "Mammal",
            Area = "Asia"
        });

        Assert.Equal(4, id);
    }

    [Fact]
    public void UpdateAnimal_Should_Return_1_When_Animal_Updated()
    {
        var animalRepository = new FakeAnimalReposiotry();
        var animalService = new AnimalService(animalRepository);

        var result = animalService.UpdateAnimal(2, new AnimalUpdateDTO
        {
            Name = "Elephant",
            Description = "Large land animal",
            Category = "Mammal",
            Area = "Asia"
        });

        Assert.Equal(1, result);
    }

    [Fact]
    public void UpdateAnimal_Should_Return_0_When_Animal_Not_Found()
    {
        var animalRepository = new FakeAnimalReposiotry();
        var animalService = new AnimalService(animalRepository);

        var result = animalService.UpdateAnimal(4, new AnimalUpdateDTO
        {
            Name = "Tiger",
            Description = "Large cat",
            Category = "Mammal",
            Area = "Asia"
        });

        Assert.Equal(0, result);
    }

    [Fact]
    public void DeleteAnimal_Should_Return_1_When_Animal_Deleted()
    {
        var animalRepository = new FakeAnimalReposiotry();
        var animalService = new AnimalService(animalRepository);

        var result = animalService.DeleteAnimal(2);

        Assert.Equal(1, result);
    }

    [Fact]
    public void DeleteAnimal_Should_Return_0_When_Animal_Not_Found()
    {
        var animalRepository = new FakeAnimalReposiotry();
        var animalService = new AnimalService(animalRepository);

        var result = animalService.DeleteAnimal(4);

        Assert.Equal(0, result);
    }
}