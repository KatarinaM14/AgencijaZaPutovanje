using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Destinacija
    {
        [Key]
        public int ID  { get; set; }

        [MaxLength(40)]
        public string Naziv { get; set; }

        [MaxLength(40)]
        public string NazivHotela { get; set; }

        public int BrojDana { get; set; }

        [Range(50, 2000)]
        public int Cena { get; set; }


        [JsonIgnore]
        public List<Spoj> DestinacijaSpoj { get; set; }
    }
}