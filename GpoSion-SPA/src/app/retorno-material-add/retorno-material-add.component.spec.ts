/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RetornoMaterialAddComponent } from './retorno-material-add.component';

describe('RetornoMaterialAddComponent', () => {
  let component: RetornoMaterialAddComponent;
  let fixture: ComponentFixture<RetornoMaterialAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RetornoMaterialAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RetornoMaterialAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
