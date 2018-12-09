import { Component, OnInit, NgModule } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { QuestionSubmissionService } from '../question-submission.service';

@Component({
  selector: 'app-question-component',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})
export class QuestionListComponent implements OnInit {

  question = {};
  questions;

  constructor(private api: QuestionSubmissionService, private route: ActivatedRoute) { }

  ngOnInit() {
    var quizId = this.route.snapshot.paramMap.get('quizId');
    this.api.getQuestions(quizId).subscribe(res => {
      console.log(res);
      this.questions = res;
    });
  }
}
