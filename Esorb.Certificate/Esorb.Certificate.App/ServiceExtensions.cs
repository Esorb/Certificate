using Microsoft.Extensions.DependencyInjection;
using System;

namespace Esorb.Certificate.App;

public static class ServiceExtensions
{
    public static void AddFactory<TObject>(this IServiceCollection services)
        where TObject : class
    {
        services.AddTransient<TObject>();
        services.AddSingleton<Func<TObject>>(x => () => x.GetService<TObject>()!);
        services.AddSingleton<IAbstractFactory<TObject>, AbstractFactory<TObject>>();
    }
}
