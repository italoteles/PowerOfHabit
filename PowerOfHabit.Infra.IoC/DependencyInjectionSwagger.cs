﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PowerOfHabit.Infra.IoC
{
    public static class DependencyInjectionSwagger 
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PowerOfHabit.API", Version = "v1" });

                //resolvendo conflitos de versões no swagger
                //c.ResolveConflictingActions(c => c.First());


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Authorization Header using JWT scheme Bearer. \r\n\r\nType 'Bearer' [space] and your token.\r\n\r\nExample: \'Bearer 12345abcdef\' ",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
                        });

            return services;
        }
    }
}
