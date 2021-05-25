/* tslint:disable:no-unused-variable */
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MotivoTiempoMuertoAddComponent } from './motivo-tiempo-muerto-add.component';

describe('MotivoTiempoMuertoAddComponent', () => {
  let component: MotivoTiempoMuertoAddComponent;
  let fixture: ComponentFixture<MotivoTiempoMuertoAddComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ MotivoTiempoMuertoAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MotivoTiempoMuertoAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
