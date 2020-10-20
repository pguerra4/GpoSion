/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RecibosTotalesComponent } from './recibos-totales.component';

describe('RecibosTotalesComponent', () => {
  let component: RecibosTotalesComponent;
  let fixture: ComponentFixture<RecibosTotalesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecibosTotalesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecibosTotalesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
