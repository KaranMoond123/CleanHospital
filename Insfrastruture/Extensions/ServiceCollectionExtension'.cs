using Application.Interfaces.Jwtservices;
using Domain.Comman;
using Domain.Comman.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Peristance.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insfrastruture.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddService();
        }
        public static void AddService(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IJwsService, JwtService>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
        }
    }
}
