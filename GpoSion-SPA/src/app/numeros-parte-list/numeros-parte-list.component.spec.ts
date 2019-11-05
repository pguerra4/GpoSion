/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NumerosParteListComponent } from './numeros-parte-list.component';

describe('NumerosParteListComponent', () => {
  let component: NumerosParteListComponent;
  let fixture: ComponentFixture<NumerosParteListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NumerosParteListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NumerosParteListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
