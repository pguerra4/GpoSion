/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { EmbarquesTop10Component } from './embarques-top10.component';

describe('EmbarquesTop10Component', () => {
  let component: EmbarquesTop10Component;
  let fixture: ComponentFixture<EmbarquesTop10Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmbarquesTop10Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmbarquesTop10Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
