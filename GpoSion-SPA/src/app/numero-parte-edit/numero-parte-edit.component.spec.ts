/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { NumeroParteEditComponent } from './numero-parte-edit.component';

describe('NumeroParteEditComponent', () => {
  let component: NumeroParteEditComponent;
  let fixture: ComponentFixture<NumeroParteEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NumeroParteEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NumeroParteEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
