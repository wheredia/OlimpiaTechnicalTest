import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Aforo } from '../../obj/aforo';

@Component({
  selector: 'app-aforo-component',
  templateUrl: './aforo.component.html'
})
export class AforoComponent implements OnInit{
  public aforoConsultado: Aforo = new Aforo(0,0,0); 
  private url: string;
  public aforoConsulted: boolean = false;
  constructor(
    private _http: HttpClient,    
    @Inject('BASE_URL') private _baseUrl: string) {
    this.url = this._baseUrl + 'Aforo/GetEstadioInfo';
  }

  ngOnInit(){

    this._http.get<any>(this.url)
      .subscribe(result => {
          this.aforoConsultado = new Aforo(result.capacidadMaxima, result.porcentajeOcupacionMaximo, result.ocupacionActual);
          console.log(this.aforoConsultado);
          this.aforoConsulted = true;
      },
        err => console.error(err));

  }  
}
