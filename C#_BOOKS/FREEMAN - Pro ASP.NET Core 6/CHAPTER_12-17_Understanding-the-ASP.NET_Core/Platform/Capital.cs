namespace Platform
{
    public class Capital
    {
        private RequestDelegate _requestDelegate;
        public Capital(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public Capital() { }
        public async Task Invoke(HttpContext httpContext)
        {
            string[] parts = httpContext.Request.Path.ToString().Split('/', StringSplitOptions.RemoveEmptyEntries);

            if(parts.Length == 2 && parts[0] == "capital") {
                string country = parts[1];

                string capital = country.ToLower() switch
                {
                    "uk" => "London",
                    "france" => "Paris",
                    "monaco" => "Monaco",
                    _ => "Unknown"
                };

                if (capital == "Monaco") httpContext.Response.Redirect($"/population/{country}");
                
                await httpContext.Response.WriteAsync($"{capital} is the capital of {country}\n");
            }
            if(_requestDelegate != null)
            {
                await _requestDelegate(httpContext);
            }
        }
    }
}
