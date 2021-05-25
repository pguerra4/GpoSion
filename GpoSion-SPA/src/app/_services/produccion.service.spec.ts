/* tslint:disable:no-unused-variable */

import { TestBed, inject, waitForAsync } from '@angular/core/testing';
import { ProduccionService } from './produccion.service';

describe('Service: Produccion', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProduccionService]
    });
  });

  it('should ...', inject([ProduccionService], (service: ProduccionService) => {
    expect(service).toBeTruthy();
  }));
});
