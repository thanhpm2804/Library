using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
IConfigurationRoot configuration = builder.Build();

string email = configuration["AdminAccount:Account"];
string password = configuration["AdminAccount:Password"];

Console.WriteLine($"Email: {email}");
Console.WriteLine($"Password: {password}");