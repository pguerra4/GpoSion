/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EmbarqueListComponent } from './embarque-list.component';

describe('EmbarqueListComponent', () => {
  let component: EmbarqueListComponent;
  let fixture: ComponentFixture<EmbarqueListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmbarqueListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmbarqueListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
