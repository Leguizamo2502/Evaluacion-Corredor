using Business.Interfaces.Implements;
using Entity.DTOs.Default;
using Entity.DTOs.Select;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;
using Web.Controllers.Base.Web.Controllers.BaseController;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    [Produces("application/json")]
    public class ClienteController : BaseController<ClienteDto, ClienteSelect, IClienteService>
    {
        public ClienteController(IClienteService service, ILogger<ClienteController> logger) : base(service, logger)
        {
        }

        protected override Task<IEnumerable<ClienteSelect>> GetAllAsync()
        {
            return _service.GetAllAsync();
        }
        protected override Task<ClienteSelect?> GetByIdAsync(int id)
        {
            return _service.GetByIdAsync(id);
        }
        protected override Task AddAsync(ClienteDto dto)
        {
            return _service.CreateAsync(dto);
        }

        protected override Task<bool> UpdateAsync(int id, ClienteDto dto)
        {
            return _service.UpdateAsync(dto);
        }

        protected override async Task<bool> DeleteAsync(int id)
        {
            var form = await _service.GetByIdAsync(id);
            if (form is null) return false;

            await _service.DeleteAsync(id);
            return true;
        }

        protected override Task<bool> DeleteLogicalAsync(int id) => _service.DeleteLogicAsync(id);
    }
}
