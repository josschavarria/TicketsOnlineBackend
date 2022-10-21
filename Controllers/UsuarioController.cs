using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;
using TicketsOnlineBackend.Services;

namespace TicketsOnlineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly UsuarioServices _UsuarioServices;

        public UsuarioController(UsuarioServices UsuarioServices)
        {
            _UsuarioServices = UsuarioServices;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetAll()
        {
            var result = _UsuarioServices.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(int id)
        {
            return Ok(await _UsuarioServices.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Usuario item)
        {
            return Ok(await _UsuarioServices.PostUsuario(item));
        }

        //CategoryDTO  agregarlos PENDIENTE


        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutC(Usuario item)
        {
            return Ok(await _UsuarioServices.PutUsuario(item));
        }


        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(Usuario item)
        {
            return Ok(await _UsuarioServices.DeleteUsuario(item.Id));
        }

        //[Autorize(Roles="Admin")]

    }
}
