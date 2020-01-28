/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MoldeadoraEditComponent } from './moldeadora-edit.component';

describe('MoldeadoraEditComponent', () => {
  let component: MoldeadoraEditComponent;
  let fixture: ComponentFixture<MoldeadoraEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MoldeadoraEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MoldeadoraEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
