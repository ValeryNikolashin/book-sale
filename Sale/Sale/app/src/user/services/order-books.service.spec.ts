import { TestBed } from '@angular/core/testing';

import { OrderBooksService } from './order-books.service';

describe('OrderBooksService', () => {
  let service: OrderBooksService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OrderBooksService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
