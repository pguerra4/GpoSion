/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UnidadMedidaService } from './unidadMedida.service';

describe('Service: UnidadMedida', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UnidadMedidaService]
    });
  });

  it('should ...', inject([UnidadMedidaService], (service: UnidadMedidaService) => {
    expect(service).toBeTruthy();
  }));
});
