using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components;

public class PageSize : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = await httpClient.GetAsync("https://github.com");
        return View(response.Content.Headers.ContentLength);
    }
}
