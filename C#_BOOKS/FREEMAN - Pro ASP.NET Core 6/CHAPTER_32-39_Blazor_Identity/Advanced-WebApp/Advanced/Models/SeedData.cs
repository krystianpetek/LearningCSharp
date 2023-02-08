using Microsoft.EntityFrameworkCore;

namespace Advanced.Models;

public static class SeedData
{
    public static void SeedDatabase(this WebApplication app)
    {
        var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
        context.Database.Migrate();

        Department d1 = new Department { Name = "Sales" };
        Department d2 = new Department { Name = "Development" };
        Department d3 = new Department { Name = "Support" };
        Department d4 = new Department { Name = "Facilities" };

        Location l1 = new Location { City = "Oakland", State = "CA" };
        Location l2 = new Location { City = "San Jose", State = "CA" };
        Location l3 = new Location { City = "New York", State = "NY" };

        Person p1 = new Person { Firstname = "Francesca", Surname = "Jacobs", Department = d2, Location = l1 };
        Person p2 = new Person { Firstname = "Charles", Surname = "Fuentes", Department = d2, Location = l3 };
        Person p3 = new Person { Firstname = "Bright", Surname = "Becker", Department = d4, Location = l1 };
        Person p4 = new Person { Firstname = "Murphy", Surname = "Lara", Department = d1, Location = l3 };
        Person p5 = new Person { Firstname = "Beasley", Surname = "Hoffman", Department = d4, Location = l3 };
        Person p6 = new Person { Firstname = "Marks", Surname = "Hays", Department = d4, Location = l1 };
        Person p7 = new Person { Firstname = "Underwood", Surname = "Trujillo", Department = d2, Location = l1 };
        Person p8 = new Person { Firstname = "Randall", Surname = "Lloyd", Department = d3, Location = l2 };
        Person p9 = new Person { Firstname = "Guzman", Surname = "Case", Department = d2, Location = l2 };

        if (!context.Departments.Any())
            context.Departments.AddRange(d1, d2, d3, d4);

        if (!context.Locations.Any())
            context.Locations.AddRange(l1, l2, l3);

        if (!context.People.Any())
            context.People.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9);

        context.SaveChanges();
    }
}
