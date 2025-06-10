using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces.Implements;
using Data.Repository;
using Entity.Domain.Models.Implements;
using Entity.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public class PedidoRepository : DataGeneric<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await _dbSet
                        .Include(u => u.Producto)
                        .Include(u => u.Cliente)
                        .Where(u => u.isDeleted == false)
                        .ToListAsync();
        }

        public override async Task<Pedido?> GetByIdAsync(int id)
        {
            return await _dbSet
                      .Include(u => u.Producto)
                      .Include(u => u.Cliente)
                      .Where(u => u.Id == id)
                      .FirstOrDefaultAsync();

        }

    }
}
