import { TestBed, inject } from '@angular/core/testing';

import { CharacterGeneratorService } from './character-generator.service';

describe('CharacterGeneratorService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CharacterGeneratorService]
    });
  });

  it('should be created', inject([CharacterGeneratorService], (service: CharacterGeneratorService) => {
    expect(service).toBeTruthy();
  }));
});
