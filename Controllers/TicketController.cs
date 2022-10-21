using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;
using TicketsOnlineBackend.Services;

namespace TicketsOnlineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly TicketServices _TicketServices;

        public TicketController(TicketServices TicketServices)
        {
            _TicketServices = TicketServices;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> GetAll()
        {
            var result = _TicketServices.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(int id)
        {
            return Ok(await _TicketServices.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Ticket item)
        {
            return Ok(await _TicketServices.PostTicket(item));
        }

        //CategoryDTO  agregarlos PENDIENTE


        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutC(Ticket item)
        {
            return Ok(await _TicketServices.PutTicket(item));
        }


        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(Ticket item)
        {
            return Ok(await _TicketServices.DeleteTicket(item.Id));
        }

        //[Autorize(Roles="Admin")]

    }
}
