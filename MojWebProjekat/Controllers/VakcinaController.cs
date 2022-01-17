using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace MojWebProjekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VakcinaController : ControllerBase
    {

        public AgencijaContext Context { get; set; }
        public VakcinaController(AgencijaContext context)
        {
            Context = context;
        }

        [Route("DodajPodatkeOVakcinaciji/{vakcinisan}/{prvaDoza}/{drugaDoza}")]
        [HttpPost]
        public async Task<ActionResult> DodajVakcinu(bool vakcinisan, bool prvaDoza, bool drugaDoza)
        {

            try
            {

                
                Vakcina v = new Vakcina
                {
                    Vakcinisan = vakcinisan,
                    PrvaDoza = prvaDoza,
                    DrugaDoza = drugaDoza,
                     
                };
                
                
                Context.Vakcinacija.Add(v);
                await Context.SaveChangesAsync();
                 return Ok(v.ID);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}