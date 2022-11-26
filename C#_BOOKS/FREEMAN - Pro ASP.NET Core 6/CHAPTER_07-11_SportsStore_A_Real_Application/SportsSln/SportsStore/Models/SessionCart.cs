﻿using System.Text.Json.Serialization;
using SportsStore.Infrastructure;

namespace SportsStore.Models;

public class SessionCart : Cart
{
    public static Cart GetCart(IServiceProvider service)
    {
        var session = service.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
        var cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();

        cart.Session = session;
        return cart;
    }

    [JsonIgnore] private ISession Session { get; set; }
    
    public override void Clear()
    {
        base.Clear();
        Session?.Remove("Cart");
    }

    public override void AddItem(Product product, int quantity)
    {
        base.AddItem(product, quantity);
        Session?.SetJson("Cart",this);
    }

    public override void RemoveItem(Product product)
    {
        base.RemoveItem(product);
        Session?.SetJson("Cart", this);
    }
}