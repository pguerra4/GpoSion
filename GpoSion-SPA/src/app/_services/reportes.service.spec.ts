/* tslint:disable:no-unused-variable */

import { TestBed, inject, waitForAsync } from '@angular/core/testing';
import { ReportesService } from './reportes.service';

describe('Service: Reportes', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ReportesService]
    });
  });

  it('should ...', inject([ReportesService], (service: ReportesService) => {
    expect(service).toBeTruthy();
  }));
});
