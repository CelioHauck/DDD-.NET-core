import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { UsuarioService } from "src/app/Service/usuario.service";

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private usuario: UsuarioService,private router: Router) {}

  canActivate() {
    if(!this.usuario.verificarLogin())
    {
       this.router.navigate(['']);
       return false;
    }

    return true;
  }
}