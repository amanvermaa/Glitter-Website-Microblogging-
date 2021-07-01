import { TestBed } from '@angular/core/testing';

import { MyTweetsService } from './my-tweets.service';

describe('MyTweetsService', () => {
  let service: MyTweetsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MyTweetsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
