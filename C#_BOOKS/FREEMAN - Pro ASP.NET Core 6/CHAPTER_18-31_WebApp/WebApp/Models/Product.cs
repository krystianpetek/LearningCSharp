﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApp.Models;

public class Product
{
    public long ProductId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(8,2)")]
    //[DisplayFormat(DataFormatString = "0:c2", ApplyFormatInEditMode = true)]
    [BindNever]
    public decimal Price { get; set; }
    
    public long CategoryId { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Category? Category { get; set; }
    
    public long SupplierId { get; set; }

    //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Supplier? Supplier { get; set; }
}
