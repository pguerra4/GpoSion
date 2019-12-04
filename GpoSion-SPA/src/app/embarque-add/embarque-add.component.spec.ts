/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EmbarqueAddComponent } from './embarque-add.component';

describe('EmbarqueAddComponent', () => {
  let component: EmbarqueAddComponent;
  let fixture: ComponentFixture<EmbarqueAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmbarqueAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmbarqueAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
