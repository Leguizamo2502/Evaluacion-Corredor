using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces.Implements;
using Data.Repository;
using Entity.Domain.Models.Implements;
using Entity.DTOs;
using Entity.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public class ClienteRepository : DataGeneric<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Cliente> ValidateClienteAsync(LoginDto loginDto)
        {
            bool suceeded = false;

            var cliente = await _dbSet

                .FirstOrDefaultAsync(u =>
                            u.Correo == loginDto.Correo);

            suceeded = (cliente != null) ? true : throw new UnauthorizedAccessException("Credenciales inválidas");

            return cliente;
        }
    }
}
