/* tslint:disable:no-unused-variable */
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RequerimientoMaterialViajerosComponent } from './requerimiento-material-viajeros.component';

describe('RequerimientoMaterialViajerosComponent', () => {
  let component: RequerimientoMaterialViajerosComponent;
  let fixture: ComponentFixture<RequerimientoMaterialViajerosComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ RequerimientoMaterialViajerosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RequerimientoMaterialViajerosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
