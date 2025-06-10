
using System;
using System.Reflection;
using System.Security;
using AutoMapper;
using Entity.Domain.Models.Implements;
using Entity.DTOs.Default;
using Entity.DTOs.Select;

namespace Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Producto, ProductoSelect>().ReverseMap();

            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Cliente, ClienteSelect>().ReverseMap();

            CreateMap<Pedido, PedidoDto>().ReverseMap();
            CreateMap<Pedido, PedidoSelect>().ReverseMap();
        }
    }
}
