/* tslint:disable:no-unused-variable */

import { TestBed, inject, waitForAsync } from '@angular/core/testing';
import { NumeroParteService } from './numeroParte.service';

describe('Service: NumeroParte', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NumeroParteService]
    });
  });

  it('should ...', inject([NumeroParteService], (service: NumeroParteService) => {
    expect(service).toBeTruthy();
  }));
});
