using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Animal
{
    public int Id { get; init; }

    [Required] [MaxLength(100)] public string Name { get; init; } = null!;

    [MaxLength(100)] public string Description { get; init; } = null!;

    [Required] [MaxLength(100)] public string Category { get; init; } = null!;

    [Required] [MaxLength(100)] public string Area { get; init; } = null!;
}