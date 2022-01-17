using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MojWebProjekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvionController : ControllerBase
    {

        public AgencijaContext Context { get; set; }
        public AvionController(AgencijaContext context)
        {
            Context = context;
        }

        [Route("DodajPodatkeOAvionu")]
        [HttpPost]

        public async Task<ActionResult> DodajAvion([FromBody] Avion avion)
        {
            if(avion.UkupanBrojSedista < 1 || avion.UkupanBrojSedista > 999)
            {
                return BadRequest("Pogresan unos!");
            }
            
            try
            {
                 Context.Avioni.Add(avion);
                 await Context.SaveChangesAsync();
                 return Ok("Avion  je dodat!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}