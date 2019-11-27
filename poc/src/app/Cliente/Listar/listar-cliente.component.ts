import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Router } from "@angular/router";
import { ClienteService } from "src/app/Service/cliente.service";
import { Cliente } from "src/app/Model/cliente";
import { OnInit } from "@angular/core";

@Component({
    selector: 'listar-cliente',
    templateUrl: './listar-cliente.component.html',
    styleUrls: ['./listar-cliente.component.css']
  })

  export class ListarClienteComponent implements OnInit{


    clientes: Cliente[];
    clientesEspeciais: Cliente[];
    cliente: Cliente = new Cliente();

    ngOnInit(): void {
        this.buscarTodos();
        this.buscarTodosClientesEspeciais();
    }

    constructor(private clienteService:ClienteService){}

    public deletar(id:number):void{
        this.clienteService.delete(id).subscribe(() => this.buscarTodos());
    }

    private buscarTodos():void{
        this.clienteService.getClientes().subscribe(clientes => this.clientes = clientes);
    }

    private buscarTodosClientesEspeciais():void{
        this.clienteService.getClientesEspeciais().subscribe(clientes => this.clientesEspeciais = clientes);
    }

}