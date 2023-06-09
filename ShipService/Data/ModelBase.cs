﻿using System.ComponentModel.DataAnnotations;

namespace ShipService.Data;

public class ModelBase
{
    [Required]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public bool Deleted { get; set; }
}