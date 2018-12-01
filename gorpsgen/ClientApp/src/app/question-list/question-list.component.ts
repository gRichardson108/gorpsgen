import { Component, OnInit } from '@angular/core';
import { QuizSubmissionService } from '../quiz-submission.service';

@Component({
  selector: 'app-question-component',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})
export class QuestionListComponent implements OnInit {

  question = {};
  questions;

  constructor(private api: QuizSubmissionService) { }

  ngOnInit() {
    this.api.getQuestions().subscribe(res => {
      this.questions = res;
    });
  }

  post(question){
    this.api.postQuestion(question);
  }

}
