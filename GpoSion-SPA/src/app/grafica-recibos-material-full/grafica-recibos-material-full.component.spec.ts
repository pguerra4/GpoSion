/* tslint:disable:no-unused-variable */
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GraficaRecibosMaterialFullComponent } from './grafica-recibos-material-full.component';

describe('GraficaRecibosMaterialFullComponent', () => {
  let component: GraficaRecibosMaterialFullComponent;
  let fixture: ComponentFixture<GraficaRecibosMaterialFullComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ GraficaRecibosMaterialFullComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GraficaRecibosMaterialFullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
