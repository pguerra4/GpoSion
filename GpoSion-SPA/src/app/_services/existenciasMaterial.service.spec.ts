/* tslint:disable:no-unused-variable */

import { TestBed, inject, waitForAsync } from '@angular/core/testing';
import { ExistenciasMaterialService } from './existenciasMaterial.service';

describe('Service: ExistenciasMaterial', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ExistenciasMaterialService]
    });
  });

  it('should ...', inject([ExistenciasMaterialService], (service: ExistenciasMaterialService) => {
    expect(service).toBeTruthy();
  }));
});
