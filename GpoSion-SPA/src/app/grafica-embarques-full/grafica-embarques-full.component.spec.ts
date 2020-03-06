/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GraficaEmbarquesFullComponent } from './grafica-embarques-full.component';

describe('GraficaEmbarquesFullComponent', () => {
  let component: GraficaEmbarquesFullComponent;
  let fixture: ComponentFixture<GraficaEmbarquesFullComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GraficaEmbarquesFullComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GraficaEmbarquesFullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
