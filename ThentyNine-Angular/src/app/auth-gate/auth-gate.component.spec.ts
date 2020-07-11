import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthGateComponent } from './auth-gate.component';

describe('AuthGateComponent', () => {
  let component: AuthGateComponent;
  let fixture: ComponentFixture<AuthGateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuthGateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthGateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
