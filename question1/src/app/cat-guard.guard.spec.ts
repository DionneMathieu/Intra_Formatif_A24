import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { catGuardGuard } from './cat-guard.guard';

describe('catGuardGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => catGuardGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
