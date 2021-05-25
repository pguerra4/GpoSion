/* tslint:disable:no-unused-variable */
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GraficaEmbarquesNpFullComponent } from './grafica-embarques-np-full.component';

describe('GraficaEmbarquesNpFullComponent', () => {
  let component: GraficaEmbarquesNpFullComponent;
  let fixture: ComponentFixture<GraficaEmbarquesNpFullComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ GraficaEmbarquesNpFullComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GraficaEmbarquesNpFullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
