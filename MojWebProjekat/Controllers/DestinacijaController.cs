using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace MojWebProjekat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DestinacijaController : ControllerBase
    {

        public AgencijaContext Context { get; set; }
        public DestinacijaController(AgencijaContext context)
        {
            Context = context;
        }

        [Route("VratiRezervacijuProba/{jmbg}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
     public async Task<ActionResult> VratiRezervacijuProba(string jmbg)
        {
           try
           {
               var rezervacije = Context.Destinacije
                    .Include(p => p.DestinacijaSpoj)
                    .ThenInclude(p => p.Klijent)
                    .Include(p => p.DestinacijaSpoj)
                    .ThenInclude(p => p.Avion);


             
                  var klijent = await rezervacije.ToListAsync();

                    return Ok
                    (
                        klijent.Select( p =>
                        new
                        {
                            Naziv = p.Naziv,
                            NazivHotela = p.NazivHotela,
                            Vreme = p.DestinacijaSpoj
                                .Where(q => q.Klijent.JmbgKlijenta == jmbg)
                                .Select(q =>
                                new
                                {
                                      VremePoletanja = q.Avion.VremePoletanja,
                                      VremeSletanja = q.Avion.VremeSletanja,
                                      BrojSedista = q.BrojSedistaKlijenta
                                })     
                            }).ToList()
                  );
           }
          catch(Exception e)
           {
                  return BadRequest(e.Message);
           }
        }


        [Route("VratiRezervaciju/{jmbg}")]
        [HttpGet]
        public async Task<ActionResult> VratiRezervaciju(string jmbg)
        {
           try
           {
                var rezervacije = Context.KlijentAvion
                    .Include(p => p.Avion)
                    .Include(p => p.Klijent)
                    .Include(p => p.Destinacija)
                    .Where( p =>  p.Klijent.JmbgKlijenta == jmbg);


             
                  var klijent = await rezervacije.ToListAsync();

                    return Ok
                    (
                        klijent.Select( p =>
                        new
                        {
                            Naziv = p.Destinacija.Naziv,
                            NazivHotela = p.Destinacija.NazivHotela,     
                            VremePoletanja = p.Avion.VremePoletanja,
                            VremeSletanja = p.Avion.VremeSletanja,
                            BrojSedista = p.BrojSedistaKlijenta
                            
                       }).ToList()
                   );
           }
           catch(Exception e)
           {
                  return BadRequest(e.Message);
           }
        }

        [Route("DodajRezervaciju/{jmbg}/{idDestinacije}/{idAviona}/{brSedista}/{idVakcine}")]
        [HttpPost]
        public async Task<ActionResult> DodajRezervaciju(string jmbg, int idDestinacije, int idAviona, int brSedista, int idVakcine)
        {
             if(string.IsNullOrWhiteSpace(jmbg) || jmbg.Length != 13)
            {
                return BadRequest("Neispravan unos!");
            }
             if(idAviona < 0)
            {
                return BadRequest("Neispravan id aviona!");
            }
             if(idDestinacije < 0)
            {
                return BadRequest("Neispravan id destinacije!");
            }
             if(idVakcine < 0)
            {
                return BadRequest("Neispravan id vakcine!");
            }



            try
            {
                 var klijent = await Context.Klijenti.Where(p => p.JmbgKlijenta == jmbg).FirstOrDefaultAsync();
                 var destinacija = await Context.Destinacije.FindAsync(idDestinacije);
                 var avion = await Context.Avioni.FindAsync(idAviona);
                
                 klijent.KlijentVakcina = await Context.Vakcinacija.FindAsync(idVakcine);

                 Spoj s = new Spoj
                 {
                    Klijent = klijent,
                    Destinacija = destinacija,
                    Avion = avion,
                    BrojSedistaKlijenta = brSedista
                 };


                 Context.KlijentAvion.Add(s);
                 await Context.SaveChangesAsync();

                 var podaciORezervaciji = await Context.KlijentAvion
                            .Include(p => p.Klijent)
                            .Include(p => p.Avion)
                            .Include(p => p.Destinacija)
                            .Where( p => p.Klijent.JmbgKlijenta == jmbg)
                            .Select( p=>
                            new
                            {
                                 ID = p.ID,
                                 Ime = p.Klijent.Ime,
                                 Prezime = p.Klijent.Prezime,
                                 Naziv = p.Destinacija.Naziv,
                                 NazivHotela = p.Destinacija.NazivHotela,
                                 VremePoletanja = p.Avion.VremePoletanja,
                                 VremeSletanja = p.Avion.VremeSletanja,
                                 BrojSedista = p.BrojSedistaKlijenta
                            }).ToListAsync();
                  return Ok(podaciORezervaciji);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

         [Route("IzmeniRezervaciju/{id}/{idDest}")]
         [HttpPut]
         public async Task<ActionResult> IzmeniRezervaciju(int id, int idDest)
         {
             if(id < 0)
             {
                 return BadRequest("Pogresan ID!");
             }
           
             try
             {
                 var spoj = await Context.KlijentAvion.FindAsync(id);

                 if(spoj == null || spoj.ID < 0)
                 {
                     return BadRequest("Rezervacija ne postoji!");
                 }
                 
                 var d = await Context.Destinacije.FindAsync(idDest);
                var a = await Context.Avioni.FindAsync(idDest);

                 spoj.Destinacija = d;
                 spoj.Avion = a;

        
                 await Context.SaveChangesAsync();
                 return Ok
                (
                       new
                       {
                            ID = spoj.ID,
                            Naziv = d.Naziv,
                            NazivHotela = d.NazivHotela,
                            VremePoletanja = a.VremePoletanja,
                            VremeSletanja = a.VremeSletanja
                       }       
                 );
              }
              catch(Exception e)
              {
                  return BadRequest(e.Message);
              }
              
         }



        [Route("ObrisiRezervaciju/{id}")]
        [HttpDelete]
        public async Task<ActionResult> ObrisiRezervaciju(int id)
        {
            if(id < 0)
            {
                return BadRequest("Pogresan ID!");
            }
            try
            {  
               var spoj = await Context.KlijentAvion.FindAsync(id);
                //var klijent= spoj.Klijent;
                
               
                if(spoj != null || spoj.ID > 0 )
                   Context.KlijentAvion.Remove(spoj);
                else
                       return BadRequest("Ne postoji objekat sa datim ID-jem!");

      

                await Context.SaveChangesAsync();
                return Ok($"Rezervacija klijenta sa ID-jem {id} je obrisana!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("VratiDestinaciju/{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> VratiDestinaciju(int id)
        {
             try
             {
                var destinacija = Context.Destinacije
                           .Where(p => p.ID == id);

                var dest = await destinacija.ToListAsync();

                return Ok
                (
                        dest.Select(p =>
                        new
                        {
                            Naziv = p.Naziv,
                            //Cena = p.Cena,
                            NazivHotela = p.NazivHotela
                        }
                        ).ToList()
                );
             }
             catch(Exception e)
             {
                 return BadRequest(e.Message);
             }
        }
        [Route("PreuzmiDestinaciju")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PreuzmiDestinaciju()
        {
             try
             {

                return Ok
                (
                        await Context.Destinacije.Select(p => new {p.ID, p.Naziv, p.Cena}).ToListAsync()
                );
             }
             catch(Exception e)
             {
                 return BadRequest(e.Message);
             }
        }

        [Route("PromeniDestinaciju")]
        [HttpPut]

        public async Task<ActionResult> IzmeniDestinaciju([FromBody] Destinacija destinacija)
        {
           if(destinacija.Cena < 50 || destinacija.Cena > 2000)
            {
                return BadRequest("Pogresan unos!");
            }
            
            if(destinacija.BrojDana < 1)
            {
                return BadRequest("Pogresan unos!");
            }

            if(string.IsNullOrWhiteSpace(destinacija.Naziv) || destinacija.Naziv.Length > 40)
            {
                return BadRequest("Neispravan unos!");
            }

            if(string.IsNullOrWhiteSpace(destinacija.NazivHotela) || destinacija.NazivHotela.Length > 40)
            {
                return BadRequest("Neispravan unos!");
            }

            try
            {
                  Context.Destinacije.Update(destinacija);

                  await Context.SaveChangesAsync();
                  return Ok("Destinacija je izmenjena!");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("DodajDestinaciju")]
        [HttpPost]

        public async Task<ActionResult> DodajDestinaciju([FromBody] Destinacija destinacija)
        {
            if(string.IsNullOrWhiteSpace(destinacija.Naziv) || destinacija.Naziv.Length > 40)
            {
                return BadRequest("Neispravan unos!");
            }

            if(string.IsNullOrWhiteSpace(destinacija.NazivHotela) || destinacija.NazivHotela.Length > 40)
            {
                return BadRequest("Neispravan unos!");
            }
            
            if(destinacija.Cena < 50 || destinacija.Cena > 2000)
             {
                 return BadRequest("Uneli ste nedozvoljenu cenu!");
             }

             try
             {
                Context.Destinacije.Add(destinacija);
                await Context.SaveChangesAsync();
                return Ok("Destinacija je dodata!");
             }
             catch(Exception e)
             {
                 return BadRequest(e.Message);
             }
        }
    }

}