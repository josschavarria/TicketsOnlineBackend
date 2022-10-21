using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;
using TicketsOnlineBackend.Services;

namespace TicketsOnlineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly CategoriaServices _CategoriaServices;

        public CategoriaController(CategoriaServices CategoriaServices)
        {
            _CategoriaServices = CategoriaServices;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetAll()
        {
            var result = _CategoriaServices.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(int id)
        {
            return Ok(await _CategoriaServices.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Categoria item)
        {
            return Ok(await _CategoriaServices.PostCategoria(item));
        }

        //CategoryDTO  agregarlos PENDIENTE


        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutC(Categoria item)
        {
            return Ok(await _CategoriaServices.PutCategoria(item));
        }


        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(Categoria item)
        {
            return Ok(await _CategoriaServices.DeleteCategoria(item.Id));
        }

        //[Autorize(Roles="Admin")]


    }
}
