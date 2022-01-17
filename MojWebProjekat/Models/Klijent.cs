using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class Klijent
    {
        [Key]
        public int ID { get; set; }

        
        [MaxLength(13)]
        public string JmbgKlijenta { get;  set; }

        [Required]
        [MaxLength(50)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(50)]
        public string Prezime { get; set; }

        
        [MaxLength(60)]
        public string Email { get; set; }

        
        
        public string BrojTelefona { get; set; }

        
        public string DatumPutovanja { get; set; }

    

        [JsonIgnore]
        public List<Spoj> KlijentSpoj { get; set; }

        public Vakcina KlijentVakcina { get; set; }
    }
}