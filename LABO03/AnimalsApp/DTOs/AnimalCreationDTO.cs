﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class AnimalCreationDTO
{
    [Required] [MaxLength(100)] public string Name { get; init; } = null!;

    [MaxLength(100)] public string Description { get; init; } = null!;

    [Required] [MaxLength(100)] public string Category { get; init; } = null!;

    [Required] [MaxLength(100)] public string Area { get; init; } = null!;
}