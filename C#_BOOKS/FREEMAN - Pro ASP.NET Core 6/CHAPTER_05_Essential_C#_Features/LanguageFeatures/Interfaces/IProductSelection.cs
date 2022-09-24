using LanguageFeatures.Models;

namespace LanguageFeatures.Interfaces;

public interface IProductSelection : IEnumerable<Product?>
{
    IEnumerable<Product>? Products { get; }

    IEnumerable<string>? Names => Products?.Select(p => p.Name);
}