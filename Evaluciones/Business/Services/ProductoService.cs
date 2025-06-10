using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces.Implements;
using Business.Repository;
using Data.Interfaces.Base;
using Entity.Domain.Models.Implements;
using Entity.DTOs.Default;
using Entity.DTOs.Select;

namespace Business.Services
{
    public class ProductoService : BusinessBasic<ProductoDto, ProductoSelect, Producto>, IProductoService
    {
        public ProductoService(IData<Producto> data, IMapper mapper) : base(data, mapper)
        {
        }
    }
}
