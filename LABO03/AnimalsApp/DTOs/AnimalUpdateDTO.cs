using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class AnimalUpdateDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string Area { get; set; } = null!;
}