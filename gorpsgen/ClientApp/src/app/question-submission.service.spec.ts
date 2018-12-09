import { TestBed, inject } from '@angular/core/testing';

import { QuestionSubmissionService } from './question-submission.service';

describe('QuestionSubmissionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QuestionSubmissionService]
    });
  });

  it('should be created', inject([QuestionSubmissionService], (service: QuestionSubmissionService) => {
    expect(service).toBeTruthy();
  }));
});
