/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MoldeService } from './molde.service';

describe('Service: Molde', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MoldeService]
    });
  });

  it('should ...', inject([MoldeService], (service: MoldeService) => {
    expect(service).toBeTruthy();
  }));
});
