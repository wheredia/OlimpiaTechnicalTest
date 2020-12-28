import { Component, Inject, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Aficionado } from '../../obj/aficionado';

@Component({
  selector: 'app-ingresar-component',
  templateUrl: './ingresar.component.html',
  styleUrls: ['./ingresar.component.css']
})
export class IngresarComponent implements OnInit {

  public aficionadoModel: Aficionado;
  public canEnter: boolean;
  public http: HttpClient;
  public url: string;
  public urlAddAficionado: string;
  public data: any;
  public wasSuccessful: boolean;


  constructor(
    private _http: HttpClient,
    private _router: Router,
    private _route: ActivatedRoute,
    @Inject('BASE_URL') private _baseUrl: string) {

    this.aficionadoModel = new Aficionado(null, null, null, null, null, null, null);
    this.http = _http;
    this.url = this._baseUrl + 'Aforo/CanEnter';
    this.urlAddAficionado = this._baseUrl + 'Aforo/AddAficionado';
    this.wasSuccessful = false;
  }

  async ngOnInit() {
    await this.cantEnter();
  }

  async cantEnter() {
    await this.http.get<boolean>(this.url)
      .subscribe(result => { this.canEnter = result; },
        err => console.error(err));
  }


  onSubmit() {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    this.http.post<any>(this.urlAddAficionado, JSON.stringify(this.aficionadoModel), { headers: headers })
                      .subscribe(result => {
                                  console.log(result);
                                  if (result) {
                                    this.wasSuccessful = true;
                                    setTimeout(() => {
                                      this._router.navigate(['/'])
                                    }, 2000);                                    
                                  }
                                },error => { console.error(error); });
  }
}
