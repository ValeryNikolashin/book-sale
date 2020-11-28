import { TestBed } from '@angular/core/testing';

import { ExitBookEditorGuard } from './exit-book-editor.guard';

describe('ExitBookEditorGuard', () => {
  let guard: ExitBookEditorGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(ExitBookEditorGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
