import { Pedido } from './../../../services/pedido/pedido.service';
import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { PedidoService } from '../../../services/pedido/pedido.service';


@Component({
  selector: 'app-pedido',
  imports: [MatButtonModule, RouterLink, MatTableModule, CommonModule],
  templateUrl: './pedido.component.html',
  styleUrl: './pedido.component.css'
})
export class PedidoComponent {

  servicio = inject(PedidoService);
  Pedido?: Pedido[] = [];

  columns = ['nameCliente', 'nameProducto','cantidad','fechaPedido' ,'action']

}
