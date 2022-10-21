using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;
using TicketsOnlineBackend.Services;

namespace TicketsOnlineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {

        private readonly EventoServices _EventoServices;

        public EventoController(EventoServices EventoServices)
        {
            _EventoServices = EventoServices;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Evento>> GetAll()
        {
            var result = _EventoServices.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(int id)
        {
            return Ok(await _EventoServices.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Evento item)
        {
            return Ok(await _EventoServices.PostEvento(item));
        }

        //CategoryDTO  agregarlos PENDIENTE


        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutC(Evento item)
        {
            return Ok(await _EventoServices.PutEvento(item));
        }


        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(Evento item)
        {
            return Ok(await _EventoServices.DeleteEvento(item.Id));
        }

        //[Autorize(Roles="Admin")]
    }
}
