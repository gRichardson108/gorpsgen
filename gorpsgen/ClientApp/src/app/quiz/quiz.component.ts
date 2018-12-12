import { Component, OnInit } from '@angular/core';
import { QuizSubmissionService } from '../quiz-submission.service';
import { Quiz } from '../models/quiz';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent implements OnInit {

  quiz: Quiz = new Quiz();

  constructor(private api: QuizSubmissionService) { }

  ngOnInit() {
    this.api.quizSelected.subscribe(quiz => this.quiz = quiz);
  }

}
