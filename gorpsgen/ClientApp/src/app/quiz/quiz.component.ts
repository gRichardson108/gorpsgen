import { Component, OnInit } from '@angular/core';
import { QuizSubmissionService } from '../quiz-submission.service';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent implements OnInit {

  quiz = {};

  constructor(private api: QuizSubmissionService) { }

  ngOnInit() {
    this.api.quizSelected.subscribe(quiz => this.quiz = quiz);
  }

}
