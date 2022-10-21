using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsOnlineBackend.Helppers;
using TicketsOnlineBackend.Models;
using TicketsOnlineBackend.Services;

namespace TicketsOnlineBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {

        private readonly VendorServices _VendorServices;

        public VendorController(VendorServices VendorServices)
        {
            _VendorServices = VendorServices;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Vendor>> GetAll()
        {
            var result = _VendorServices.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetById(int id)
        {
            return Ok(await _VendorServices.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(Vendor item)
        {
            return Ok(await _VendorServices.PostVendor(item));
        }

        //CategoryDTO  agregarlos PENDIENTE


        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutC(Vendor item)
        {
            return Ok(await _VendorServices.PutVendor(item));
        }


        [HttpPut]
        public async Task<ActionResult<Response>> DeleteById(Vendor item)
        {
            return Ok(await _VendorServices.DeleteVendor(item.Id));
        }

        //[Autorize(Roles="Admin")]

    }
}
