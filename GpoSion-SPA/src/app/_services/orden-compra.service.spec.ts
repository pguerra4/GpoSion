/* tslint:disable:no-unused-variable */

import { TestBed, inject, waitForAsync } from '@angular/core/testing';
import { OrdenCompraService } from './orden-compra.service';

describe('Service: OrdenCompra', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OrdenCompraService]
    });
  });

  it('should ...', inject([OrdenCompraService], (service: OrdenCompraService) => {
    expect(service).toBeTruthy();
  }));
});
