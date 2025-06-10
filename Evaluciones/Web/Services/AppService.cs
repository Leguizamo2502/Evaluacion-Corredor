using Business.Interfaces.Implements;
using Business.Interfaces.Jwt;
using Business.JwtCustom;
using Business.Services;
using Data.Interfaces.Base;
using Data.Interfaces.Implements;
using Data.Repository;
using Data.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Web.AutoMapper;

namespace Web.Services
{

    public static class AppService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IPedidoService, PedidoService>();

            services.AddScoped(typeof(IData<>), typeof(DataGeneric<>));
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IToken, TokenBusiness>();







            return services;
        }
    }
}
