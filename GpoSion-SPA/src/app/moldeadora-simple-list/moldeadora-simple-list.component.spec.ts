/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MoldeadoraSimpleListComponent } from './moldeadora-simple-list.component';

describe('MoldeadoraSimpleListComponent', () => {
  let component: MoldeadoraSimpleListComponent;
  let fixture: ComponentFixture<MoldeadoraSimpleListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MoldeadoraSimpleListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MoldeadoraSimpleListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
