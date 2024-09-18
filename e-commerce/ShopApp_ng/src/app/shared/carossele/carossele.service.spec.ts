import { TestBed } from '@angular/core/testing';

import { CarosseleService } from './carossele.service';

describe('CarosseleService', () => {
  let service: CarosseleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarosseleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
