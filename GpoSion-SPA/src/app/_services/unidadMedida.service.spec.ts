/* tslint:disable:no-unused-variable */

import { TestBed, inject, waitForAsync } from '@angular/core/testing';
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
