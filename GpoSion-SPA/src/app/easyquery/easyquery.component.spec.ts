/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EasyqueryComponent } from './easyquery.component';

describe('EasyqueryComponent', () => {
  let component: EasyqueryComponent;
  let fixture: ComponentFixture<EasyqueryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EasyqueryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EasyqueryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
