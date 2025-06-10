using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces.Base;
using Entity.Domain.Models.Implements;
using Entity.DTOs;

namespace Data.Interfaces.Implements
{
    public interface IClienteRepository : IData<Cliente>  
    {
        Task<Cliente> ValidateClienteAsync(LoginDto loginDto);
    }
}
