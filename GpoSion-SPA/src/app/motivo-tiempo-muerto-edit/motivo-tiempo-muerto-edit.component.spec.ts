/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MotivoTiempoMuertoEditComponent } from './motivo-tiempo-muerto-edit.component';

describe('MotivoTiempoMuertoEditComponent', () => {
  let component: MotivoTiempoMuertoEditComponent;
  let fixture: ComponentFixture<MotivoTiempoMuertoEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MotivoTiempoMuertoEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MotivoTiempoMuertoEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
