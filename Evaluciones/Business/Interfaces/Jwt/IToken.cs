using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DTOs;

namespace Business.Interfaces.Jwt
{
    public interface IToken
    {
        Task<string> GenerateToken(LoginDto dto);
        bool validarToken(string token);
    }
}
