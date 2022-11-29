using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Data;
using SportsStore.Models;

namespace SportsStore.Pages;

public class CartModel : PageModel
{
    private IStoreRepository _repository;
    public Cart Cart { get; set; }

    public CartModel(IStoreRepository repository, Cart cartService)
    {
        _repository = repository;
        Cart = cartService;
    }
    public string ReturnUrl { get; set; } = "/";

    public void OnGet(string returnUrl) 
    {
        ReturnUrl = returnUrl ?? "/";
    }

    public IActionResult OnPost(long productId, string returnUrl)
    {
        var product = _repository.Products.FirstOrDefault(x => x.ProductId == productId);
        if (product != null)
        {
            Cart.AddItem(product, 1);
        }

        return RedirectToPage(new { returnUrl = returnUrl });
    }

    public IActionResult OnPostRemove(long productId, string returnUrl)
    {
        Cart.RemoveItem(Cart.Lines.First(x => x.Product.ProductId == productId).Product);
        return RedirectToPage(new { returnUrl = returnUrl });
    }
}