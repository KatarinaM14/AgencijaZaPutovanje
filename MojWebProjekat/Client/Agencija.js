import { Klijent } from "./Klijent.js";


export class Agencija{

    constructor(listaDestinacija){
        this.listaDestinacija = listaDestinacija;
        this.kont = null;
    }

    crtaj(host){
        this.kont=document.createElement("div");
        this.kont.className="GlavniKontejner";
        host.appendChild(this.kont);

        let a = document.createElement("div");
        a.className = "NazivAgencije";
        this.kont.appendChild(a);

        this.crtajNaziv(a);

        let kontDest = document.createElement("div");
        kontDest.className="listaDestinacija";
        this.kont.appendChild(kontDest);

        let kontRezervisi = document.createElement("div");
        kontRezervisi.className = "FormaZaRezervaciju";
        this.kont.appendChild(kontRezervisi);

        let kontRezervacijeKlijenta = document.createElement("div");
        kontRezervacijeKlijenta.className = "SveRezervacije";
        this.kont.appendChild(kontRezervacijeKlijenta);


        let kontDest2 = document.createElement("div");
        kontDest2.className="listaDestinacija";
        kontDest.appendChild(kontDest2);
       
        this.crtajDest(kontDest2);

        

        let kontDestBtn = document.createElement("div");
        kontDestBtn.className="listaDestinacijaBtn";
        kontDest.appendChild(kontDestBtn);

        let btnRezervisi = document.createElement("button");
        btnRezervisi.className = "btnRezrvDest";
        btnRezervisi.onclick = (ev) => this.crtajRezervaciju();
        btnRezervisi.innerHTML = "Rezervacija";
        kontDestBtn.appendChild(btnRezervisi);

      
        this.crtajSliku(this.kont);
    }

    crtajNaziv(host){
          let lbl = document.createElement("label");
          lbl.className = "lblAgencija";
          lbl.innerHTML = "Agencija Travelling application";
          host.appendChild(lbl);
    }
  

   crtajSliku(host){
    let divSLike = document.createElement("div");
     divSLike.className="DivSlike";
     host.appendChild(divSLike);

      let slika = document.createElement("img");
        slika.src = "slika2.png";
      slika.className = "Slika2";
       divSLike.appendChild(slika);
        
      
       let slika1 = document.createElement("img");
       slika1.src = "slika1.jpeg";
     slika1.className = "Slika1";
     divSLike.appendChild(slika1);

     let slika4 = document.createElement("img");
     slika4.src = "slika4.jpeg";
      slika4.className = "Slika4";
      divSLike.appendChild(slika4);

    }
    crtajKonacniPrikaz(host){
      

        var tabela = document.createElement("tabela");
        tabela.className = "TabelaRezervacije";
        host.appendChild(tabela);

        var tabelahead = document.createElement("thead");
        tabelahead.className = "HeadPodaci";
        tabela.appendChild(tabelahead);

        var tr = document.createElement("tr");
        tr.className = "trPodaci";
        tabelahead.appendChild(tr);

        var tabelaBody = document.createElement("tbody");
        tabelaBody.className = "TabelaPodaciKonacno";
        tabela.appendChild(tabelaBody);

        let th;
        var zaglavlje = ["Ime", "Prezime", "Destinacija", "Naziv hotela", "Vreme poletanja", "Vreme sletanja", "Broj sedista"];
        zaglavlje.forEach(el =>{
            th = document.createElement("th");
            th.innerHTML = el;
            tr.appendChild(th);
        })
    }

    crtajDest(host){
          var tabela = document.createElement("table");
          tabela.className="tabelaDest";
          host.appendChild(tabela);

          var tabelahead = document.createElement("thead");
          tabela.appendChild(tabelahead);

          var tr = document.createElement("tr");
          tr.className = "trDest1";
          tabelahead.appendChild(tr);

          var tabelaBody = document.createElement("tbody");
          tabelaBody.className="TabelaPodaci";
          tabela.appendChild(tabelaBody);

          let th;
          var zaglavlje=["Destinacija", "Cena"];
          zaglavlje.forEach(el =>{
              th = document.createElement("th");
              th.innerHTML = el;
              tr.appendChild(th);
          })

          this.listaDestinacija.forEach( d =>{
              d.crtajDestinaciju(tabela);
          })
    }


    crtajRezervaciju(){
        
        var formaRezerv = document.querySelector(".FormaZaRezervaciju");
        this.kont.removeChild(formaRezerv);

        formaRezerv  = document.createElement("div");
        formaRezerv.className = "FormaZaRezervaciju";
        this.kont.appendChild(formaRezerv);


        this.proveriVakcinaciju(formaRezerv);
       
        let DesniLevi = document.createElement("div");
        DesniLevi.className = "DesniLevi";
        formaRezerv.appendChild(DesniLevi);
        

         let divLevi = document.createElement("div");
         divLevi.className = "DivLevi";
         DesniLevi .appendChild(divLevi);

         let divDesni = document.createElement("div");
         divDesni.className = "DivDesni";
         DesniLevi .appendChild(divDesni);


         this.crtajLeviDiv(divLevi);

         this.crtajDesniDiv(divDesni);

    }

    proveriVakcinaciju(host){


        let divVakcina = document.createElement("div");
        divVakcina.className = "DivVakcina";
        host.appendChild(divVakcina);

        let lblVakcina = document.createElement("div");
        lblVakcina.className = "LblVakcina";
        divVakcina.appendChild(lblVakcina);

        let divDoza = document.createElement("div");
        divDoza.className = "DivDoza";
        divVakcina.appendChild(divDoza);

        let labeleDoza = document.createElement("div");
        labeleDoza.className = "LabeleDoza";
        divDoza.appendChild(labeleDoza);

        let checkboxDoza = document.createElement("div");
        checkboxDoza.className = "CheckboxDoza";
        divDoza.appendChild(checkboxDoza);

        let l = document.createElement("label");
        l.innerHTML = "Da li ste vakcinisani?(Da/Ne)";
        lblVakcina.appendChild(l);
        var polje = document.createElement("input");
        polje.type = "text";
        polje.className = "VakcinaText";
        lblVakcina.appendChild(polje);
         
         let prvaDoza = document.createElement("input");
         prvaDoza.type = "checkbox";
         prvaDoza.value = 1;
         prvaDoza.className = "cbxPrvaD";
         checkboxDoza.appendChild(prvaDoza);

         l = document.createElement("label");
         l.innerHTML = "Jedna doza";
         labeleDoza.appendChild(l);

         let drugaDoza = document.createElement("input");
         drugaDoza.type = "checkbox";
         drugaDoza.value = 2;
         prvaDoza.className = "cbxDrugaD";
         checkboxDoza.appendChild(drugaDoza);

         l = document.createElement("label");
         l.innerHTML = "Dve doze";
         labeleDoza.appendChild(l);

         

    }

    crtajLeviDiv(host){

        let labeleLevo = document.createElement("div");
        labeleLevo.className = "LabeleLevo";
        host.appendChild(labeleLevo);

        let textLevo = document.createElement("div");
        textLevo.className = "TextLevo";
        host.appendChild(textLevo);

        let l = document.createElement("label");
        l.innerHTML = "Ime";
        labeleLevo.appendChild(l);
        var poljeIme = document.createElement("input");
        //poljeIme.type = "text";
        poljeIme.className = "ImeText";
        textLevo.appendChild(poljeIme);

        l = document.createElement("label");
        l.innerHTML = "Prezime";
        labeleLevo.appendChild(l);
        var polje = document.createElement("input");
        polje.className = "PrezimeText";
        textLevo.appendChild(polje);

        l = document.createElement("label");
        l.innerHTML = "Email";
        labeleLevo.appendChild(l);
        polje = document.createElement("input");
        polje.className = "EmailText";
        textLevo.appendChild(polje);


        l = document.createElement("label");
        l.innerHTML = "Broj";
        labeleLevo.appendChild(l);
        polje = document.createElement("input");
        polje.className = "BrojText";
        textLevo.appendChild(polje);

        l = document.createElement("label");
        l.innerHTML = "Jmbg";
        labeleLevo.appendChild(l);
        polje = document.createElement("input");
        polje.className = "JmbgText";
        textLevo.appendChild(polje);

    }

    crtajDesniDiv(host){
        
        let labeleDesno = document.createElement("div");
        labeleDesno.className = "LabeleDesno";
        host.appendChild(labeleDesno);

        let textDesno = document.createElement("div");
        textDesno.className = "TextDesno";
        host.appendChild(textDesno);

        let l = document.createElement("label");
        l.className = "LabelaDest"
        l.innerHTML = "Izaberite destinaciju";
        labeleDesno.appendChild(l);

        let s = document.createElement("select");
        s.className = "IzborDest";
        textDesno.appendChild(s);
          
        let option;
        this.listaDestinacija.forEach(p =>{
            option = document.createElement("option");
            option.innerHTML = p.naziv;
            option.value = p.id;
            s.appendChild(option);
        })

      


        l = document.createElement("label");
        l.innerHTML = "Broj dana";
        l.className = "BrDana";
        labeleDesno.appendChild(l);
        var polje = document.createElement("input");
        polje.type = "number";
        polje.className = "BrojDanaText";
        textDesno.appendChild(polje);


        let btnRezervisanaDest = document.createElement("button");
        btnRezervisanaDest.className = "DugmeRezervisi";
        btnRezervisanaDest.onclick = (ev) => this.rezervacijaKlijenta();
        btnRezervisanaDest.innerHTML = "Dodaj rezervaciju";
        textDesno.appendChild(btnRezervisanaDest);
        
    }

    rezervacijaKlijenta(){

        let v = this.kont.querySelector(".VakcinaText");
        var vakc = v.value;

        console.log(vakc);

        if(vakc === "Ne"){
            alert("Ne mozete da putujete ukoliko niste vakcinisani!");
            return;
        }
          
         let d = this.kont.querySelector("input[type='checkbox']:checked");
         var doza = d.value;
        console.log(doza);
         
        if(doza == 1){
            alert("Ne mozete da putujete sa jednom dozom vakcine!");
            return;
        }

        let i = this.kont.querySelector(".ImeText");
        var ime = i.value;

        console.log(ime);

        if(ime === null || ime === undefined || ime === ""){
            alert("Niste popunili sva polja!");
            return;
        }

        let p = this.kont.querySelector(".PrezimeText");
        var prezime = p.value;

        console.log(prezime);

        if(prezime === null || prezime === undefined || prezime === ""){
            alert("Niste popunili sva polja!");
            return;
        }
        
        let e = this.kont.querySelector(".EmailText");
        var email = e.value;

        console.log(email);

        if(email === null || email === undefined || email === ""){
            alert("Niste popunili sva polja!");
            return;
        }

        
        let t= this.kont.querySelector(".BrojText");
        var brTel =  t.value;

        console.log(brTel);

        if(brTel === null || brTel === undefined || brTel === ""){
            alert("Niste popunili sva polja!");
            return;
        }

        let j= this.kont.querySelector(".JmbgText");
        var jmbg =  j.value;

        console.log(jmbg);

        if(jmbg === null || jmbg === undefined || jmbg === ""){
            alert("Niste popunili sva polja!");
            return;
        }
        else if(jmbg.length != 13){
            alert("Jmbg mora da se sastoji od 13 cifara!");
            return;
        }
        

        d= this.kont.querySelector(".IzborDest");
        let dest =  d.options[d.selectedIndex].value;

        console.log(dest);

        if(dest === null || dest === undefined || dest === "")
        {
            alert("Niste popunili sva polja!");
            return;
        }
        
        d= this.kont.querySelector(".BrojDanaText");
        let brDana =  d.value;

        console.log(brDana);

        if(brDana === null || brDana === undefined || brDana === "")
        {
            alert("Niste popunili sva polja!");
            return;
        }
        
       

        this.DodajKlijentaIVakcinu(ime, prezime, email, brTel, jmbg, vakc, doza, dest);
    }

    DodajKlijentaIVakcinu(ime, prezime, email, brTel, jmbg, vakc, doza, dest)
    {
        var v;
        if(vakc === "Da"){
            v = true;
        }
        else{
            v = false;
        }

        var prvaD, drugaD;

        if(doza === 1){
            prvaD = true;
            drugaD = false;
        }
        else{
            prvaD = true;
            drugaD = true;
        }
        var datumP;
        var brojSedista;
        var idAviona;
        var VakcinaID;
        if(dest == 1){
             idAviona = 1;
             datumP = "30.01.2022 17:00";
             brojSedista = Math.floor(Math.random() * 650) + 1;
        }
        else if(dest == 2){
             idAviona = 2;
             datumP = "30.01.2022 12:00";
             brojSedista = Math.floor(Math.random() * 600) + 1;
        }
        else if(dest == 3){
            idAviona = 3;
            datumP = "30.01.2022 09:00";
            brojSedista = Math.floor(Math.random() * 550) + 1;
        }
        else if(dest == 4){
            idAviona = 4;
            datumP = "31.01.2022 14:00";
            brojSedista = Math.floor(Math.random() * 650) + 1;
        }
        else if(dest == 5){
            idAviona = 5;
            datumP = "31.01.2022 17:00";
            brojSedista = Math.floor(Math.random() * 600) + 1;
        }
        else if(dest == 6){
            idAviona = 6;
            datumP = "31.01.2022 12:00";
            brojSedista = Math.floor(Math.random() * 550) + 1;
        }
        else if(dest == 7){
            idAviona = 7;
            datumP = "31.01.2022 09:00";
            brojSedista = Math.floor(Math.random() * 650) + 1;
        }
        else if(dest == 8){
            idAviona = 8;
            datumP = "31.01.2022 14:00";
            brojSedista = Math.floor(Math.random() * 600) + 1;
        }
        else if(dest == 9){
            idAviona = 9;
            datumP = "30.01.2022 17:00";
            brojSedista = Math.floor(Math.random() * 550) + 1;
        }


        fetch("https://localhost:5001/Vakcina/DodajPodatkeOVakcinaciji/"+v+"/"+prvaD+"/"+drugaD,
        {
            method:"POST"
        }).then( p =>
            {
                console.log(p.status);
                console.log(p);
                if(p.status == 200)
                {
                    //console.log("Dodati su podaci o vakcini!");
                    p.json().then( data =>{
                        console.log(data);
                        VakcinaID = data;
                        console.log("Id vakcine je "+ VakcinaID);

                        this.klijent(jmbg, ime, prezime, email, brTel, datumP, dest, idAviona, brojSedista, VakcinaID);
                    })

                }
                
            })
            .catch(e =>{
                console.log(e);
                alert("Greska pri dodavanju podataka o vakcini!");
            });

            

            
    }

    klijent(jmbg, ime, prezime, email, brTel, datumP, dest, idAviona, brojSedista, VakcinaID){

        console.log("Id vakcine nakon fje: "+ VakcinaID);
            var idKlijenta;
            fetch("https://localhost:5001/Klijent/DodavanjeKlijenta/"+jmbg+"/"+ime+"/"+prezime+"/"+email+"/"+brTel+"/"+datumP,
            {
                method:"POST"
            }).then( k =>
                {
                    console.log(k.status);
                    console.log(k);
                    if(k.status == 200)
                    {
                        k.json().then(data =>{
                            console.log("Klijent je dodat!");
                            idKlijenta = data;

                            
                        })
                        this.rezervacija(jmbg, dest, idAviona, brojSedista, VakcinaID )
                    }

                  
                })
                .catch( p =>{
                    console.log(p);
                    alert("Greska pri dodavanju klijenta!");
                });

            console.log("Vakcina id: " + VakcinaID);
            console.log("Avion id: " + idAviona);
            console.log("Destinacija id: " + dest);

            
    }

    rezervacija(jmbg, dest, idAviona, brojSedista, idVakc ){

        fetch("https://localhost:5001/Destinacija/DodajRezervaciju/"+jmbg+"/"+dest+"/"+idAviona+"/"+brojSedista+"/"+idVakc,
            {
                method:"POST"
            }).then(k =>
                {
                    console.log(k.status);
                    console.log(k);
                    if(k.status == 200)
                    {
                        var konacniPrikaz = this.obrisiKonacniPrikaz();
                        this.crtajKonacniPrikaz(konacniPrikaz);
                        k.json().then(data =>{
                            console.log(data);
                            data.forEach(k =>{
                                const r = new Klijent(k.id, k.ime, k.prezime,k.naziv, k.nazivHotela, k.vremePoletanja,k.vremeSletanja, k.brojSedista);
                                r.crtajSveRezervacije(document.querySelector(".TabelaPodaciKonacno"));

                                console.log("Id rezervacije: "+k.id);
                                console.log("Ime klijenta: "+k.ime);
                                console.log("Prezime klijenta: "+k.prezime);
                                console.log("Naziv destinacije: "+k.naziv);
                                console.log("Naziv hotela: "+k.nazivHotela);
                                console.log("Vreme poletanja: "+k.vremePoletanja);
                                console.log("Vreme sletanja: "+k.vremeSletanja);
                                console.log("Broj sedista: "+k.brojSedista);
                            });
                        })
                    }
                })
                .catch(p =>{
                    console.log(p);
                    alert("Doslo je do problema pri dodavanju vase rezervacije!");
                });
    }

    obrisiKonacniPrikaz(){

        var prikaz = document.querySelector(".SveRezervacije");
        this.kont.removeChild(prikaz);

        prikaz = document.createElement("div");
        prikaz.className = "SveRezervacije";
        this.kont.appendChild(prikaz);
        return prikaz;

    }

    vratiListuDest(){
        return this.listaDestinacija;
    }
}