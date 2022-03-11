import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public caminhoes: Caminhao[] = [];
  public httpClient: HttpClient;
  public baseURL: string

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.baseURL = baseUrl;
    this.httpClient = http;
    this.httpClient.get<Caminhao[]>(this.baseURL + 'caminhao').subscribe(result => {
      this.caminhoes = result;
    }, error => console.error(error));
  }

  public editTruck(id: number) {
    this.router.navigateByUrl('/counter?id=' + id)
  }

  public deleteTruck(id: number) {
    if (confirm("Deseja realmente excluir o caminhão de id " + id)) {
      this.httpClient.delete(this.baseURL + 'caminhao/' + id).subscribe(result => {
        confirm("Caminhão " + id + " deletado com sucesso")
      }, error => console.error(error))
    }
  }
}

interface Caminhao {
  id: number;
  name: string;
  modelo: string;
  anoFab: number;
  anoMod: number;
}
