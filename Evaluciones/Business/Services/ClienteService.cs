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
    public class ClienteService : BusinessBasic<ClienteDto, ClienteSelect, Cliente>, IClienteService
    {
        public ClienteService(IData<Cliente> data, IMapper mapper) : base(data, mapper)
        {
        }
    }
}
