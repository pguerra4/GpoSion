/* tslint:disable:no-unused-variable */

import { TestBed, inject, waitForAsync } from '@angular/core/testing';
import { ReciboService } from './recibo.service';

describe('Service: Recibo', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ReciboService]
    });
  });

  it('should ...', inject([ReciboService], (service: ReciboService) => {
    expect(service).toBeTruthy();
  }));
});
