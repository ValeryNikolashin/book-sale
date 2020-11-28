import { TestBed } from '@angular/core/testing';

import { AdministrationApiService } from './administration-api.service';

describe('AdministrationApiService', () => {
  let service: AdministrationApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdministrationApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
