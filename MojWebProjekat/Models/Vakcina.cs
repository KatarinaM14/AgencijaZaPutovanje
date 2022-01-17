using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Vakcina
    {
        [Key]
        public int ID { get; set; }

        public bool Vakcinisan { get; set; }

        public bool PrvaDoza { get; set; }

        public bool DrugaDoza { get; set; }

       [JsonIgnore]
        public List<Klijent> VakcinaKlijent { get; set; }
    }
}