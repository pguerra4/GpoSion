/* tslint:disable:no-unused-variable */

import { TestBed, inject, waitForAsync } from '@angular/core/testing';
import { RequerimientoMaterialService } from './requerimientoMaterial.service';

describe('Service: RequerimientoMaterial', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RequerimientoMaterialService]
    });
  });

  it('should ...', inject([RequerimientoMaterialService], (service: RequerimientoMaterialService) => {
    expect(service).toBeTruthy();
  }));
});
