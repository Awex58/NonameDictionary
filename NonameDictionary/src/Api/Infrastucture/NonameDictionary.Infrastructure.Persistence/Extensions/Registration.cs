﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NonameDictionary.Api.Application.Interfaces.Repositories;
using NonameDictionary.Infrastructure.Persistence.Context;
using NonameDictionary.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Infrastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NonameDictionaryContext>(conf =>
            {
                var connStr = configuration["NonameDictionaryDbConnectionString"].ToString();
                conf.UseSqlServer(connStr,opt =>
                {
                    opt.EnableRetryOnFailure();
                    
                });
            });
            //var seedata = new SeedData();
            //seedata.SeedAsync(configuration).GetAwaiter().GetResult();   tabloları dumb veri ile dolduruyor 1 kere çalıştırıldı

            services.AddScoped<IUserRepository, UserRepository>(); // inject ediyoruz dependency için 
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IEmailConfirmationRepository, EmailConfirmationRepository>();
            services.AddScoped<IEntryCommentRepository, EntryCommentRepository>();

            return services;
        }
    }
}
