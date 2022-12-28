using Microsoft.EntityFrameworkCore;

namespace Platform.Models;

public class SeedData
{
    private readonly CalculationContext _calculationContext;
    private readonly ILogger<SeedData> _logger;

    private static Dictionary<int, long> data = new Dictionary<int, long>()
    {
        {1,1},{2,3},{3,6},{4,10},{5,15},{6,21},{7,28},{8,36},{9,45},{10,55}
    };

    public SeedData(CalculationContext calculationContext, ILogger<SeedData> logger)
    {
        _calculationContext = calculationContext;
        _logger = logger;
    }

    public void SeedDatabase()
    {
        _calculationContext.Database.Migrate();
        if (_calculationContext.Calculations?.Count() == 0)
        {
            _logger.LogInformation("Preparing to seed database");
            _calculationContext.Calculations.AddRange(data.Select(kvp =>
            {
                return new Calculation()
                {
                    Count = kvp.Key,
                    Result = kvp.Value,
                };
            }));
            _calculationContext.SaveChanges();
            _logger.LogInformation("Database seeded");
        }
        else
        {
            _logger.LogInformation("Database not seeded");
        }
    }
}
