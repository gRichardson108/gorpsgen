import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { QuestionSubmissionService } from '../question-submission.service';
import { Question } from '../models/question';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  question: Question = new Question();
  quizId: string;

  constructor(private api: QuestionSubmissionService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.quizId = this.route.snapshot.paramMap.get('quizId');
    console.log(this.quizId);
    this.api.questionSelected.subscribe(question => this.question = question);
  }

  post(question){
    question.quizId = this.quizId;
    this.api.postQuestion(question);
  }

  newQuestion(){
    this.question = new Question();
  }

}
