using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace MojWebProjekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KlijentController : ControllerBase
    {

        public AgencijaContext Context { get; set; }
        public KlijentController(AgencijaContext context)
        {
            Context = context;
        }
        
        [EnableCors("CORS")]
        [Route("DodajKlijenta")]
        [HttpPost]
        public async Task<ActionResult> DodajKlijenta([FromBody] Klijent klijent)
        {
            if(string.IsNullOrWhiteSpace(klijent.JmbgKlijenta) || klijent.JmbgKlijenta.Length != 13)
            {
                return BadRequest("Neispravan unos!");
            }

            if(string.IsNullOrWhiteSpace(klijent.Ime) || klijent.Ime.Length > 40)
            {
                return BadRequest("Neispravan unos!");
            }
            if(string.IsNullOrWhiteSpace(klijent.Prezime) || klijent.Prezime.Length > 40)
            {
                return BadRequest("Neispravan unos!");
            }

            try
            {
                Context.Klijenti.Add(klijent);
                await Context.SaveChangesAsync();
                 return Ok("Klijent je dodat!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("IzbrisiKlijenta/{id}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiKlijenta(int id)
        {
            if(id <= 0)
            {
                return BadRequest("Pogresan ID!");
            }

            try
            {
                  var klijent = await Context.Klijenti.FindAsync(id);
                  Context.Klijenti.Remove(klijent);
                  await Context.SaveChangesAsync();
                  return Ok("Klijent je izbrisan!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [Route("Rezervacija/{jmbg}/{idDestinacije}")]
        [HttpPost]
        public async Task<ActionResult> DodajRezervaciju(string jmbg, int idDestinacije)
        {
            if(string.IsNullOrWhiteSpace(jmbg) || jmbg.Length != 13)
            {
                return BadRequest("Neispravan unos!");
            }
            
            try
            {
                 var klijent = await Context.Klijenti.Where(p => p.JmbgKlijenta == jmbg).FirstOrDefaultAsync();
                 var destinacija = await Context.Destinacije.FindAsync(idDestinacije);

                 Spoj s = new Spoj
                 {
                    Klijent = klijent,
                    Destinacija = destinacija
                 };

                 Context.KlijentAvion.Add(s);
                 await Context.SaveChangesAsync();

                 return Ok(s);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       
        [EnableCors("CORS")]
        [Route("DodavanjeKlijenta/{jmbg}/{ime}/{prezime}/{email}/{brTel}/{datumP}")]
        [HttpPost]
        public async Task<ActionResult> DodavajeKlijenta(string jmbg,string ime, string prezime, string email, string brTel, string datumP)
        {
            if(string.IsNullOrWhiteSpace(jmbg) || jmbg.Length != 13)
            {
                return BadRequest("Neispravan unos!");
            }

            if(string.IsNullOrWhiteSpace(ime) || ime.Length > 40)
            {
                return BadRequest("Neispravan unos!");
            }
            if(string.IsNullOrWhiteSpace(prezime) || prezime.Length > 40)
            {
                return BadRequest("Neispravan unos!");
            }

            try
            {
               // var vakcina = await Context.Vakcinacija.FindAsync(idVakcine);
                var kl = await Context.Klijenti.Where(p => p.JmbgKlijenta == jmbg).FirstOrDefaultAsync();
                if(kl != null)
                     return Ok(kl.ID);

                Klijent klijent = new Klijent
                {
                      JmbgKlijenta = jmbg,
                      Ime = ime,
                      Prezime = prezime,
                      Email = email,
                      BrojTelefona = brTel,
                      DatumPutovanja = datumP,
                };

                Context.Klijenti.Add(klijent);
                await Context.SaveChangesAsync();
                 return Ok(klijent.ID);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
