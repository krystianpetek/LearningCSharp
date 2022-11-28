﻿using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly Cart _cartService;
    
    public CartSummaryViewComponent(Cart cartService)
    {
        _cartService = cartService;
    }

    public IViewComponentResult Invoke()
    {
        return View("Default", _cartService);
    }
}