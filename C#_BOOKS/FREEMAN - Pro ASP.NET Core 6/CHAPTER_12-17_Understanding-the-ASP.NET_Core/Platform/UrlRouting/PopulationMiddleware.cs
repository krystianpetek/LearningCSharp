namespace Platform.UrlRouting
{
    public class PopulationMiddleware
    {
        private RequestDelegate? _requestDelegate;

        public PopulationMiddleware() { }
        public PopulationMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string[] parts = httpContext.Request.Path.ToString().Split("/", StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 2 && parts[0] == "population")
            {
                string city = parts[1];
                int population = city switch
                {
                    "london" => 8_136_000,
                    "paris" => 2_141_000,
                    "monaco" => 39_000,
                    _ => 0
                };
                await httpContext.Response.WriteAsync($"City: {city}, Population: {population}\n");
            }

            if (_requestDelegate != null)
            {
                await _requestDelegate(httpContext);
            }
        }
    }
}
