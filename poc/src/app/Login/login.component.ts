import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Router } from "@angular/router";
import { Usuario } from "src/app/Model/usuario";
import { UsuarioService } from "src/app/Service/usuario.service";
import { OnInit } from "@angular/core";


@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
  })

  export class LoginComponent implements OnInit{

    public usuario: Usuario = new Usuario();

    public desabilitarAlert: boolean = true;
    
    constructor(private route: ActivatedRoute, private router: Router, private usuarioService: UsuarioService){};

    ngOnInit(): void {
      this.limparToken();
    }
  

    public logar(){
      this.usuarioService.logar(this.usuario)
                         .subscribe( response =>{
                           if(response != null){
                            let resources = response["auth_token"];
                            localStorage.setItem('auth_token',resources);
                            this.router.navigate(['/listar']);
                           }else{
                             this.desabilitarAlert = false;
                           }
                         });
    }

    private limparToken(): void{
      localStorage.removeItem('auth_token');
    }

    }

  