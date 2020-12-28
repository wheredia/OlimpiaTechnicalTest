import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Aficionado } from '../../obj/aficionado';

@Component({
  selector: 'app-salir-component',
  templateUrl: './salir.component.html',
  styleUrls: ['./salir.component.css']
})
export class SalirComponent implements OnInit {
  public aficionadoModel: Aficionado;
  public url: string;
  public wasSuccessful: boolean;

  constructor(
    private _http: HttpClient,
    private _router: Router,
    private _route: ActivatedRoute,
    @Inject('BASE_URL') private _baseUrl: string
  ) {
    this.url = this._baseUrl + 'Aforo/Out';
    this.wasSuccessful = false;
    this.aficionadoModel = new Aficionado(null, null, null, null, null, null, null);
  }

  ngOnInit() { }

  onSubmit() {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    this._http.put<any>(this.url, JSON.stringify(this.aficionadoModel.NroIdentificacion), { headers: headers })
      .subscribe(result => {
        console.log(result);
        if (result) {
          this.wasSuccessful = true;
          setTimeout(() => {
            this._router.navigate(['/'])
          }, 2000);
        }
      }, error => { console.error(error); });
  }
}
