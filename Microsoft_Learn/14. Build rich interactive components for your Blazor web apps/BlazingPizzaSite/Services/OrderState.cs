﻿using BlazingPizzaSite.Models;

namespace BlazingPizzaSite.Services;

public class OrderState
{
    public bool ShowingConfigureDialog { get; private set; }
    public Pizza ConfiguringPizza { get; private set; }
    public Order Order { get; private set; } = new Order();

    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Toppings = new List<PizzaTopping>(),
        };

        ShowingConfigureDialog = true;
        ConfiguringPizza.Size = ConfiguringPizza.DefaultSize;
    }

    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
    }

    public void ConfirmConfigurePizzaDialog()
    {
        Order.Pizzas.Add(ConfiguringPizza);
        ConfiguringPizza = null;
        ShowingConfigureDialog = false;
    }

    public void RemoveConfiguredPizza(Pizza configuredPizza)
    {
        Order.Pizzas.Remove(configuredPizza);
    }

    public void ResetOrder()
    {
        Order = new Order();
    }
}