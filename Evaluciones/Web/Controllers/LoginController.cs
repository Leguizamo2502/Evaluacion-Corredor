using Business.Interfaces.Implements;
using Business.Interfaces.Jwt;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exceptions;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IToken _token;
        private readonly ILogger<LoginController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IClienteService _clienteService;

        public LoginController(IToken token, ILogger<LoginController> logger, IConfiguration configuration, IClienteService clienteService)
        {
            _token = token;
            _logger = logger;
            _configuration = configuration;
            _clienteService = clienteService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            try
            {
                var token = await _token.GenerateToken(login);

                

                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token });

                //return Ok(token);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida para el inicio de sesión");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear el token");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("ValidarToken")]
        public IActionResult ValidarToken([FromQuery] string token)

        {

            bool respuesta = _token.validarToken(token);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = respuesta });

        }
    }



}
