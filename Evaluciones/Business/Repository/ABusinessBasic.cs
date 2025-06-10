using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces.Basic;
using Entity.Domain.Models.Base;

namespace Business.Repository
{
    public abstract class ABusinessBasic<TDto, TDtoGet, TEntity> : IBusiness<TDto, TDtoGet> where TEntity : BaseModel
    {
        public abstract Task<TDto> CreateAsync(TDto dto);
        public abstract Task<bool> DeleteAsync(int id);
        public abstract Task<bool> DeleteLogicAsync(int id);
        public abstract Task<IEnumerable<TDtoGet>> GetAllAsync();
        public abstract Task<TDtoGet?> GetByIdAsync(int id);
        public abstract Task<bool> UpdateAsync(TDto dto);
    }
}
