﻿using Application.Contracts;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAskGameManager, AskGameManager>();
        services.AddScoped<ISpinGameManager, SpinGameManager>();

        return services;
    }
}