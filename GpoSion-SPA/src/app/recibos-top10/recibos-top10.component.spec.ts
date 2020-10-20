/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RecibosTop10Component } from './recibos-top10.component';

describe('RecibosTop10Component', () => {
  let component: RecibosTop10Component;
  let fixture: ComponentFixture<RecibosTop10Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecibosTop10Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecibosTop10Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
