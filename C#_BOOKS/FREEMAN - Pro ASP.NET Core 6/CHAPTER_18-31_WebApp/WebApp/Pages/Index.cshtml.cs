using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages;

public class IndexModel : PageModel
{
    private DataContext _dataContext;
    public Product? Product { get; set; }
    public IndexModel(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task OnGetAsync(long id = 1)
    {
        Product = await _dataContext.Products.FindAsync(id);
    }
}