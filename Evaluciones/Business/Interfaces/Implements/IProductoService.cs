using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces.Basic;
using Entity.DTOs.Default;
using Entity.DTOs.Select;

namespace Business.Interfaces.Implements
{
    public interface IProductoService : IBusiness<ProductoDto, ProductoSelect>
    {
    }
}
