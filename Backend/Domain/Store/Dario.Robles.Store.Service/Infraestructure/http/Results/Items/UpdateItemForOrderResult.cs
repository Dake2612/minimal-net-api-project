﻿using Dario.Robles.Store.Service.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Dario.Robles.Store.Service.Infraestructure.http.Results.Items
{
    public class UpdateItemForOrderResult
    {
        public ItemDto ItemUpserted { get; set; }
        public List<ValidationResult> ValidationErrors { get; set; } = new();
        public bool Success { get; set; }
    }
}
