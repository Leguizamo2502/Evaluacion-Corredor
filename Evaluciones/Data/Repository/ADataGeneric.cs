using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces.Base;
using Entity.Domain.Models.Base;

namespace Data.Repository
{
    public abstract class ADataGeneric<T> : IData<T> where T : BaseModel
    {
        public abstract Task<T> CreateAsync(T entity);
        public abstract Task<bool> DeleteAsync(int id);
        public abstract Task<bool> DeleteLogicAsync(int id);
        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract Task<T?> GetByIdAsync(int id);
        public abstract Task<bool> UpdateAsync(T entity);
    }
}
