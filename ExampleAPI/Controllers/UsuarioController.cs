using Core;
using ExampleAPI.Filters;
using ExampleWebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserITApp.Entities;
using UserITApp.Services;

namespace ExampleAPI.Controllers
{
    [ServiceFilter(typeof(ErrorFilter))]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicioGenerico<Usuario> _usuarioService;
        private readonly ResponseFactory _responseFactory;

        public UsuarioController(IServicioGenerico<Usuario> usuarioService, ResponseFactory responseFactory)
        {
            this._usuarioService = usuarioService;
            this._responseFactory  = responseFactory;
        }

       
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(SucessResponse<IEnumerable<Usuario>>) , StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public IActionResult GetAll() {


            StateExecution<IEnumerable<Usuario>> state = _usuarioService.Get();

            return _responseFactory.CreateReponse(state);

        }



    }
}
