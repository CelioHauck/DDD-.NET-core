import { Http} from '@angular/http';
import { Injectable } from '@angular/core';
import { AbstractHttpService } from './abstract-http.service';
import { Cliente } from "src/app/Model/cliente";
import { Observable } from "rxjs";

@Injectable()
export class ClienteService extends AbstractHttpService<Cliente>{

  constructor(http : Http) {
    super('Cliente', http);
  }

  public getClientes(): Observable<Cliente[]> {
    return this.queryAll();
  }

  public getClientesEspeciais() : Observable<Cliente[]>{
    return this.queryAllPath("clientes-especiais");
  }
}