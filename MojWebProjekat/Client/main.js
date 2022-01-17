import { Agencija } from "./Agencija.js";
import { Destinacija } from "./Destinacija.js";
import { Klijent } from "./Klijent.js";



var listaDestinacija = [];

var agencija1;

fetch("https://localhost:5001/Destinacija/PreuzmiDestinaciju")
.then(p =>{
    p.json().then(destinacije =>{
        destinacije.forEach(destinacija =>{

            if(destinacija.id < 7)
            {
              var d = new Destinacija(destinacija.id, destinacija.naziv, destinacija.cena);
              listaDestinacija.push(d);
            }
        });

         agencija1 = new Agencija(listaDestinacija);
         agencija1.crtaj(document.body);
    })
})
console.log(listaDestinacija);



var listaDestinacija1 = [];
var agencija2;

fetch("https://localhost:5001/Destinacija/PreuzmiDestinaciju")
.then(p =>{
    p.json().then(destinacije =>{
        destinacije.forEach(destinacija =>{
  
             if(destinacija.id > 6 )
             {
                var d = new Destinacija(destinacija.id, destinacija.naziv, destinacija.cena);
                listaDestinacija1.push(d);
             }
        });

        agencija2 = new Agencija(listaDestinacija1);
       // agencija2.crtaj(document.body);
    })
})
console.log(listaDestinacija1);