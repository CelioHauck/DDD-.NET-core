

import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Router } from "@angular/router";
import { ClienteService } from "src/app/Service/cliente.service";
import { Cliente } from "src/app/Model/cliente";
import {Location} from '@angular/common';

@Component({
    selector: 'cadastar-cliente',
    templateUrl: './cadastrar-editar-cliente.component.html',
    styleUrls: ['./cadastrar-editar-cliente.component.css']
  })

  export class CadastrarEditarClienteComponent{

    public cliente:Cliente = new Cliente();
    public btn_persistir:string = "Salvar";
    public titulo:string = "Cadastrar Cliente";
    private id:number;
    
    constructor(private clienteService: ClienteService, private route: ActivatedRoute, private router: Router, private _location: Location){};

    ngOnInit() {
      this.getCliente();
    }

    private getCliente():void{
      this.id = this.route.snapshot.params.id;
      if(this.id != null){
        this.clienteService.get(this.id).subscribe(
          cliente =>{
            this.cliente = cliente;
            this.mudarBotao();
            this.mudarTitulo();
          }
        )
      }
    }

    private mudarBotao():void{
      (this.id != null) ? this.btn_persistir = "Editar" : this.btn_persistir = "Salvar";
    }

    private mudarTitulo(): void{
      debugger;
      (this.id != null) ? this.titulo = "Editar Cliente" : this.titulo = "Cadastrar Cliente";
    }

    public persistir():void{
      (this.id != null) ? this.editar() : this.salvar();
    }

    private salvar():void {
      this.clienteService.post(this.cliente).subscribe(
        sucess =>{
          this.router.navigate(['/listar']);
        }
      )
    }

    public voltar():void{
      this._location.back();
    }

    private editar():void {
      this.clienteService.put(this.cliente).subscribe(
        sucess =>{
          this.router.navigate(['/listar']);
        }
      )
    }
  }