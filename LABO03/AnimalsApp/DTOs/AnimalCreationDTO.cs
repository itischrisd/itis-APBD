using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class AnimalCreationDto
{
    [Required] [StringLength(50)]
    public string Name { get; set; } = null;
    public string Description { get; set; }
    public string Category { get; set; }
    public string Area { get; set; }
}