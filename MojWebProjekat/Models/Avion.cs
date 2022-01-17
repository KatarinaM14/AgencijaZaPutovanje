using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Avion
    {
        [Key]
        public int ID { get; set; }

        [Range(1,999)]
        public int UkupanBrojSedista { get; set; }

        public string VremePoletanja { get; set; }

        public string VremeSletanja { get; set; }


      [JsonIgnore]
       public List<Spoj> AvionSpoj { get; set; }
    }
}