namespace LanguageFeatures.Models;

public static class MyAsyncMethods
{
    public static Task<long?> GetPageLengthObsolete()
    {
        HttpClient client = new();
        var httpTask = client.GetAsync("https://apress.com");
        return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) => antecedent.Result.Content.Headers.ContentLength);
    }

    public static async Task<long?> GetPageLengthAsync()
    {
        HttpClient client = new();
        var httpMessage = await client.GetAsync("https://apress.com");
        return httpMessage.Content.Headers.ContentLength;
    }
    
    public static async Task<IEnumerable<long?>> GetPageLengthsAsync(List<string> output, params string[] urls)
    {
        List<long?> result = new();
        HttpClient httpClient = new();
        foreach (string url in urls)
        {
            output.Add($"Started request for {url}");
            var httpMessage = await httpClient.GetAsync($"http://{url}");
            result.Add(httpMessage.Content.Headers.ContentLength);
            output.Add($"Completed request for {url}");
        }

        return result;
    }
} 