using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StreamResponseController : ControllerBase
{

    [HttpGet("enumerated")]
    public IAsyncEnumerable<int> GetIAsyncEnumerable()
    {
        return GetNumbersAsync();
    }

    private async IAsyncEnumerable<int> GetNumbersAsync()
    {
        for (int i = 0; i <= 10; i++)
        {
            await Task.Delay(1000);
            yield return i;
        }
    }

    [HttpGet("generated")]
    public async IAsyncEnumerable<int> GenerateNumbersAsync()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return await ProduceNumberAsync(i);
        }
    }
    private async Task<int> ProduceNumberAsync(int seed)
    {
        await Task.Delay(1000);
        return 2 * seed;
    }
}
