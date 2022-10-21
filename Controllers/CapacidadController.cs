using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;
using TicketsOnlineBackend.Services;

namespace TicketsOnlineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacidadController : ControllerBase
    {

        private readonly CapacidadServices _CapacidadServices;

        public CapacidadController(CapacidadServices CapacidadServices)
        {
            _CapacidadServices = CapacidadServices;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Capacidad>> GetAll()
        {
            var result = _CapacidadServices.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(int id)
        {
            return Ok(await _CapacidadServices.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Capacidad item)
        {
            return Ok(await _CapacidadServices.PostCapacidad(item));
        }

        //CategoryDTO  agregarlos PENDIENTE


        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutC(Capacidad item)
        {
            return Ok(await _CapacidadServices.PutCapacidad(item));
        }


        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(Capacidad item)
        {
            return Ok(await _CapacidadServices.DeleteCapacidad(item.Id));
        }

        //[Autorize(Roles="Admin")]


    }
}
