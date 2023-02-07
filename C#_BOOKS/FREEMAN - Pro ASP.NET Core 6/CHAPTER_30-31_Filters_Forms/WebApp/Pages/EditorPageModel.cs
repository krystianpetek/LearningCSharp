using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using WebApp.Models.ViewModels;

namespace WebApp.Pages;

public class EditorPageModel : PageModel
{
    public DataContext DataContext { get; set; }
    public EditorPageModel(DataContext dataContext)
    {
        DataContext= dataContext;
    }
    public IEnumerable<Category> Categories => DataContext.Categories;
    public IEnumerable<Supplier> Suppliers => DataContext.Suppliers;

    public ProductViewModel? ViewModel { get; set; }
}
