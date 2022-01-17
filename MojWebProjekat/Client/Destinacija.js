export class Destinacija{

    constructor(id, naziv, cena){
        this.id = id;
        this.naziv = naziv;
        this.cena = cena;
    } 

    crtajDestinaciju(host)
    {
        var tr = document.createElement("tr");
        tr.className = "trDest";
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML = this.naziv;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.cena;
        tr.appendChild(el);

        
    }
}