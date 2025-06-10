import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GenericService } from '../generic/generic.service';

export interface Pedido {
  Id: number;
  ClienteId: number;
  ProductoId: number;
  ClienteNombre: string;
  ProductoNombre: string;
  Cantidad: number;
  FechaPedido: Date;
 
}
export interface PedidoCreate {
  Id: number;
  ClienteId: number;
  ProductoId: number;
  ClienteNombre: string;
  ProductoNombre: string;
  Cantidad: number;
  FechaPedido: Date;
 
}

@Injectable({
  providedIn: 'root'
})


export class PedidoService extends GenericService<Pedido, PedidoCreate>{

  constructor(http: HttpClient) {
    super(http, 'pedido');
  }
}
