using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages;

public class EditorModel : PageModel
{
    private readonly DataContext _dataContext;
    public Product Product { get; set; } = new Product();

    public EditorModel(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task OnGetAsync(long id)
    {
        Product = await _dataContext.Products.FindAsync(id) ?? new Product(); 
    }

    public async Task<IActionResult> OnPostAsync(long id, decimal price)
    {
        Product? product = await _dataContext.Products.FindAsync(id);
        if(product is not null)
        {
            product.Price = price;
        }
        await _dataContext.SaveChangesAsync();
        return Redirect($"/Editor/{id}");
    }
}
