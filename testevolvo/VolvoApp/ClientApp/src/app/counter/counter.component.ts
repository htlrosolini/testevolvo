import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentTruck: Caminhao = new Caminhao(0, '', 'FH', 2021, 2022);
  public models = ['FH', 'FM'];
  public modYear = [2022, 2023];
  public httpClient: HttpClient;
  public baseURL: string
  public title: string = "Criar Caminhão";

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute, private router: Router) {
    this.baseURL = baseUrl;
    this.httpClient = http;
  }

  public save() {
    if (this.currentTruck.id != 0) {
      this.httpClient.put<Caminhao>(this.baseURL + 'caminhao', this.currentTruck).subscribe(result => {
        confirm("Caminhão de id " + this.currentTruck.id + " editado com sucesso");
        this.router.navigateByUrl('/fetch-data')
      }, error => console.error(error));
    }
    else {
      this.httpClient.post<Caminhao>(this.baseURL + 'caminhao', this.currentTruck).subscribe(result => {
        this.currentTruck = result;
        confirm("Caminhão adicionado com sucesso no id " + this.currentTruck.id);
      }, error => console.error(error));
    }
  }

  ngOnInit() {
    this.route.queryParams
      .subscribe(params => {
        if (params.id != null) {
          this.title = "Editar Caminhão"
          this.httpClient.get<Caminhao>(this.baseURL + 'caminhao/' + params.id).subscribe(result => {
            this.currentTruck = result;
          }, error => console.error(error));
        }
      }
      );
  }
}

export class Caminhao {
  public id: number;
  public name: string;
  public modelo: string;
  public anoFab: number;
  public anoMod: number;

  constructor(
    id: number,
    name: string,
    modelo: string,
    anoFab: number,
    anoMod: number) {
    this.id = id;
    this.name = name;
    this.modelo = modelo;
    this.anoFab = anoFab;
    this.anoMod = anoMod;
  }
}
