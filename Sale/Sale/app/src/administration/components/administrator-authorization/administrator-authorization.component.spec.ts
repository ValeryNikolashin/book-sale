import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministratorAuthorizationComponent } from './administrator-authorization.component';

describe('AdministratorAuthorizationComponent', () => {
  let component: AdministratorAuthorizationComponent;
  let fixture: ComponentFixture<AdministratorAuthorizationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdministratorAuthorizationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdministratorAuthorizationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
