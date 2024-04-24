using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddAplicationRegistration(this IServiceCollection services)
        {
            var assmbly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assmbly));

            services.AddAutoMapper(assmbly);

            services.AddValidatorsFromAssembly(assmbly);

            return services;
        }
    }
}
