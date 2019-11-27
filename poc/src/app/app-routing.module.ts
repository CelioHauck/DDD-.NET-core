import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from "@angular/core";
import { CadastrarEditarClienteComponent } from "src/app/Cliente/Cadastrar-Editar/cadastrar-editar-cliente.component";
import { ListarClienteComponent } from "src/app/Cliente/Listar/listar-cliente.component";
import { LoginComponent } from "src/app/Login/login.component";
import { AuthGuard } from "src/app/auth.guard";


const routes: Routes = [
{path: '', component: LoginComponent },
{path: 'cadastrar', component: CadastrarEditarClienteComponent, canActivate: [AuthGuard] },
{path: 'editar/:id', component: CadastrarEditarClienteComponent,canActivate: [AuthGuard] },
{path: 'listar', component: ListarClienteComponent,canActivate: [AuthGuard]} 
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);