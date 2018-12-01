import { TestBed, inject } from '@angular/core/testing';

import { QuizSubmissionService } from './quiz-submission.service';

describe('QuizSubmissionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QuizSubmissionService]
    });
  });

  it('should be created', inject([QuizSubmissionService], (service: QuizSubmissionService) => {
    expect(service).toBeTruthy();
  }));
});
