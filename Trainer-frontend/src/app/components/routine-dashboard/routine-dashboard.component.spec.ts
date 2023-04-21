import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoutineDashboardComponent } from './routine-dashboard.component';

describe('RoutineDashboardComponent', () => {
  let component: RoutineDashboardComponent;
  let fixture: ComponentFixture<RoutineDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoutineDashboardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RoutineDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
