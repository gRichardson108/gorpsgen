import { Component, OnInit } from '@angular/core';
import { QuizSubmissionService } from '../quiz-submission.service';

@Component({
  selector: 'app-quiz-list',
  templateUrl: './quiz-list.component.html',
  styleUrls: ['./quiz-list.component.css']
})
export class QuizListComponent implements OnInit {

  quiz = {};
  quizzes;

  constructor(private api: QuizSubmissionService) { }

  ngOnInit() {
    this.api.getQuizzes().subscribe(res => {
      this.quizzes = res;
    })
  }
}
