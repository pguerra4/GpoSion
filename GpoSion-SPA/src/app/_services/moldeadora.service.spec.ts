/* tslint:disable:no-unused-variable */

import { TestBed, inject, waitForAsync } from '@angular/core/testing';
import { MoldeadoraService } from './moldeadora.service';

describe('Service: Moldeadora', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MoldeadoraService]
    });
  });

  it('should ...', inject([MoldeadoraService], (service: MoldeadoraService) => {
    expect(service).toBeTruthy();
  }));
});
