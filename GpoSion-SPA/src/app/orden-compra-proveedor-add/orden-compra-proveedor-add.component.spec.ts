/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { OrdenCompraProveedorAddComponent } from './orden-compra-proveedor-add.component';

describe('OrdenCompraProveedorAddComponent', () => {
  let component: OrdenCompraProveedorAddComponent;
  let fixture: ComponentFixture<OrdenCompraProveedorAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrdenCompraProveedorAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdenCompraProveedorAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
