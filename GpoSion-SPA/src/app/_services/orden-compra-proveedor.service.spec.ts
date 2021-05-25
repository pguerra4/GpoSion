/* tslint:disable:no-unused-variable */

import { TestBed, inject, waitForAsync } from '@angular/core/testing';
import { OrdenCompraProveedorService } from './orden-compra-proveedor.service';

describe('Service: OrdenCompraProveedor', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OrdenCompraProveedorService]
    });
  });

  it('should ...', inject([OrdenCompraProveedorService], (service: OrdenCompraProveedorService) => {
    expect(service).toBeTruthy();
  }));
});
