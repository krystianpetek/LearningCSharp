using Newtonsoft.Json;
using WorkWithJSON;

var addressesSerialized = File.ReadAllText("../../../Addresses.json");
var peopleSerialized = File.ReadAllText("../../../People.json");
var addresses = JsonConvert.DeserializeObject<List<Address>>(addressesSerialized);
var people = JsonConvert.DeserializeObject<List<Person>>(peopleSerialized);

var linq = people.Join(addresses, q => q.Id, w => w.PersonId, (q, w) => (q.Name, w.Street, w.City));

foreach (var z in linq)
{
    Console.WriteLine($"Name: {z.Name}, address: {z.Street}, {z.City}");
}

var linq2 = people.GroupJoin(addresses, q => q.Id, w => w.PersonId, (q, w) => new { q, add = w });

foreach (var z in linq2)
{
    Console.WriteLine($"Name: {z.q.Name}");
    foreach (var x in z.add)
    {
        Console.WriteLine($"City: {x.City}, street {x.Street}");
    }
}