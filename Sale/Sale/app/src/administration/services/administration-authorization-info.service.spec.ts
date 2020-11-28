import { TestBed } from '@angular/core/testing';

import { AdministrationAuthorizationInfoService } from './administration-authorization-info.service';

describe('AdministrationAuthorizationInfoService', () => {
  let service: AdministrationAuthorizationInfoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdministrationAuthorizationInfoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
