/* tslint:disable:no-unused-variable */
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MotivoTiempoMuertoListComponent } from './motivo-tiempo-muerto-list.component';

describe('MotivoTiempoMuertoListComponent', () => {
  let component: MotivoTiempoMuertoListComponent;
  let fixture: ComponentFixture<MotivoTiempoMuertoListComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ MotivoTiempoMuertoListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MotivoTiempoMuertoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
