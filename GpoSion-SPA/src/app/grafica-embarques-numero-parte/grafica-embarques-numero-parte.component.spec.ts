/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GraficaEmbarquesNumeroParteComponent } from './grafica-embarques-numero-parte.component';

describe('GraficaEmbarquesNumeroParteComponent', () => {
  let component: GraficaEmbarquesNumeroParteComponent;
  let fixture: ComponentFixture<GraficaEmbarquesNumeroParteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GraficaEmbarquesNumeroParteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GraficaEmbarquesNumeroParteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
