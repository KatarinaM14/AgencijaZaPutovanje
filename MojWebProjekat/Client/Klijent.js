import { Agencija } from "./Agencija.js";
import { Destinacija } from "./Destinacija.js";


export class Klijent
{
    constructor(id, ime, prezime, naziv, nazivHotela, vremePoletanja, vremeSletanja, brojSedista)
    {
        this.id = id;
        this.ime = ime;
        this.prezime = prezime;
        this.naziv = naziv;
        this.nazivHotela = nazivHotela;
        this.vremePoletanja = vremePoletanja;
        this.vremeSletanja = vremeSletanja;
        this.brojSedista = brojSedista;
    }

    crtajSveRezervacije(host){


        var tr = document.createElement("tr");
        tr.className="Red";
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML = this.ime;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.prezime;
        tr.appendChild(el);

        el = document.createElement("td");
        el.className = "NazivDest";
        el.innerHTML = this.naziv;
        tr.appendChild(el);

        el = document.createElement("td");
        el.className = "Hotel";
        el.innerHTML = this.nazivHotela;
        tr.appendChild(el);

        el = document.createElement("td");
        el.className = "VrPoletanja";
        el.innerHTML = this.vremePoletanja;
        tr.appendChild(el);

        el = document.createElement("td");
        el.className= "VrSletanja";
        el.innerHTML = this.vremeSletanja;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.brojSedista;
        tr.appendChild(el);


        el = document.createElement("td");
        tr.appendChild(el);
        let btn = document.createElement("button");
        btn.className = "ButtonDelete";
        btn.innerHTML = "Obrisi rezervaciju";
        el.appendChild(btn);
        btn.onclick = (ev) => this.obrisiRezervaciju(host);

        el = document.createElement("td");
        tr.appendChild(el);
        let btnIzmeni = document.createElement("button");
        btnIzmeni.className = "ButtonUpdate";
        btnIzmeni.innerHTML = "Izmeni rezervaciju";
        el.appendChild(btnIzmeni);
        btnIzmeni.onclick = (ev) => this.izmeniRezervaciju(tr);

    }

    obrisiRezervaciju(host){
          
        var  idRezerv = host.querySelector(".Red");
        var IDR = idRezerv.id;
        console.log("ID rezervacije koja se brise je: " + IDR);
        
        fetch("https://localhost:5001/Destinacija/ObrisiRezervaciju/"+this.id,
        {
            method:"DELETE"
        }).then(p =>{
            if(p.ok){
                
                     this.obrisiRed();
               
            }
        })
          console.log("Obrisana je rezrvacija sa ID-jem: " + this.id);
    }

    obrisiRed()
    {
        var red = document.querySelector(".Red");
        var roditelj = red.parentNode;
        roditelj.removeChild(red);

        
        
    }

    izmeniRezervaciju(host){


       var listaDest = [];


       fetch("https://localhost:5001/Destinacija/PreuzmiDestinaciju")
       .then(p =>{
           p.json().then(destinacije =>{
               destinacije.forEach(destinacija =>{
       
                   if(destinacija.id < 7)
                   {
                     var d = new Destinacija(destinacija.id, destinacija.naziv, destinacija.cena);
                     listaDest.push(d);
                   }
               });
       
              this.crtajDestZaIzmenu(host, listaDest);
           })
       })

      
    }

    crtajDestZaIzmenu(host, listaDest){

        let s = document.createElement("select");
        s.className = "IzmeniDest";
        host.appendChild(s);
        
        let option;
        listaDest.forEach(p =>{
            option = document.createElement("option");
            option.innerHTML = p.naziv;
            option.value = p.id;
            s.appendChild(option);
        })

        var el = document.createElement("td");
        host.appendChild(el);
        let btnIzmeni = document.createElement("button");
         btnIzmeni.className = "BtnUpdate";
        btnIzmeni.innerHTML = "Izmeni";
        el.appendChild(btnIzmeni);

        alert("Izaberite novu destinaciju");
        

        btnIzmeni.onclick = (ev) => {

            let d = s.options[s.selectedIndex].value;
            this.izmena(d);
        }
    }


    izmena(d){
        console.log("ID izmenjene destinacije je: "+ d);

        var n;
        var nH;
        var vp;
        var vs;

         console.log("Id  rezervacije je: " + this.id);


         fetch("https://localhost:5001/Destinacija/IzmeniRezervaciju/"+ this.id+"/"+d,
         {
             method:"PUT",
             headers:{
                 "Content-Type":"application/json"
             }
         }).then(p =>{
             if(p.ok){
                 p.json().then(data =>{
                  
                        n = data.naziv;
                        nH = data.nazivHotela;
                        vp = data.vremePoletanja;
                        vs = data.vremeSletanja;
    
    
                        console.log("Nova dest: " +n);
                        console.log("Novi hotel: " +nH);
                        console.log("Novo vreme poletanja: " + vp);
                        console.log("Novo vreme sletanja: " +vs);
    
    
                        this.upisiNovuDest(n , nH, vp, vs);
                  
           
                 })
             }
         })

           
         
    }

    upisiNovuDest(n , nH,  vp, vs){

        
        var naz = document.querySelector(".NazivDest");
        naz.innerHTML = "";
        naz.innerHTML = n;

        var h = document.querySelector(".Hotel");
        h.innerHTML = "";
        h.innerHTML = nH;

        var poletanje = document.querySelector(".VrPoletanja");
        poletanje.innerHTML = "";
        poletanje.innerHTML = vp;
      
        
        var sletanje = document.querySelector(".VrSletanja");
        sletanje.innerHTML = "";
        sletanje.innerHTML = vs;
    
       
    }
}