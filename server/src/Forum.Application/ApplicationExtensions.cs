using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Application;

public static class ApplicationExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(c => 
            c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}