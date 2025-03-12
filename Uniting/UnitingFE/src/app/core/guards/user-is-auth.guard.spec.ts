import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { userIsAuthGuard } from './user-is-auth.guard';

describe('userIsAuthGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => userIsAuthGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
