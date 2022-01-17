using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Spoj
    {
        [Key]
        public int ID { get; set; }

        [Range(1,999)]
        public int BrojSedistaKlijenta { get; set; }


        public Destinacija Destinacija { get; set; } 

        public Klijent Klijent { get; set; }

        public Avion Avion { get; set; }

        
    }
}