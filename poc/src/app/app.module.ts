import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CadastrarEditarClienteComponent } from "src/app/Cliente/Cadastrar-Editar/cadastrar-editar-cliente.component";
import { HttpModule } from "@angular/http";
import { routing } from "src/app/app-routing.module";
import { ClienteService } from "src/app/Service/cliente.service";
import { FormsModule } from '@angular/forms';
import { ListarClienteComponent } from "src/app/Cliente/Listar/listar-cliente.component";
import { LoginComponent } from "src/app/Login/login.component";
import { UsuarioService } from "src/app/Service/usuario.service";
import { AuthGuard } from "src/app/auth.guard";
import { XHRBackend } from "@angular/http";
import { XhrBack } from "src/app/xhr.backend";

@NgModule({
  declarations: [
    AppComponent,
    CadastrarEditarClienteComponent,
    ListarClienteComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    routing,
    HttpModule,
    FormsModule
  ],
  providers: [ClienteService, 
              UsuarioService, 
              AuthGuard, { 
                provide: XHRBackend, 
                useClass: XhrBack
              }],
  bootstrap: [AppComponent]
})
export class AppModule { }
