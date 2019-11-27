import { Http} from '@angular/http';
import { Injectable } from '@angular/core';
import { AbstractHttpService } from './abstract-http.service';
import { Observable } from "rxjs";
import { Usuario } from "src/app/Model/usuario";

@Injectable()
export class UsuarioService extends AbstractHttpService<Usuario>{

  private login:boolean;

  constructor(http : Http) {
    super('Usuario', http);
  }

  public logar (usuario:Usuario){
    return this.postPath(usuario, "login");
  }

  public verificarLogin(): boolean{
    return  localStorage.getItem('auth_token') != null;
  }

}