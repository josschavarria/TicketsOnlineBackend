using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;
using TicketsOnlineBackend.Services;

namespace TicketsOnlineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {

        private readonly TarjetaServices _TarjetaServices;

        public TarjetaController(TarjetaServices TarjetaServices)
        {
            _TarjetaServices = TarjetaServices;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Tarjeta>> GetAll()
        {
            var result = _TarjetaServices.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(int id)
        {
            return Ok(await _TarjetaServices.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Tarjeta item)
        {
            return Ok(await _TarjetaServices.PostTarjeta(item));
        }

        //CategoryDTO  agregarlos PENDIENTE


        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutC(Tarjeta item)
        {
            return Ok(await _TarjetaServices.PutTarjeta(item));
        }


        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(Tarjeta item)
        {
            return Ok(await _TarjetaServices.DeleteTarjeta(item.Id));
        }

        //[Autorize(Roles="Admin")]

    }
}
