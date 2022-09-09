﻿using BlazingPizzaSite.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizzaSite.Data;

public class PizzaStoreContext : DbContext
{
    public PizzaStoreContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<PizzaSpecial> Specials { get; set; }
    public DbSet<OldPizza> OldPizzas { get; set; }

}
