import { Component, OnInit } from '@angular/core';
import { QuizSubmissionService } from '../quiz-submission.service';

@Component({
  selector: 'app-quiz-question',
  templateUrl: './quiz-question.component.html',
  styleUrls: ['./quiz-question.component.css']
})
export class QuizQuestionComponent implements OnInit {

  question = {};

  constructor(private api: QuizSubmissionService) { }

  ngOnInit() {
  }

  post(question){
    this.api.postQuestion(question);
  }

}
