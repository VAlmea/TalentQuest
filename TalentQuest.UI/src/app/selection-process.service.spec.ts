import { TestBed } from '@angular/core/testing';

import { SelectionProcessService } from './selection-process.service';

describe('SelectionProcessService', () => {
  let service: SelectionProcessService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SelectionProcessService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
