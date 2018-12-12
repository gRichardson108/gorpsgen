import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';
import { Question } from './models/question';

@Injectable()
export class QuestionSubmissionService {

  private selectedQuestion: Subject<Question> = new Subject<Question>();
  questionSelected: Observable<Question> = this.selectedQuestion.asObservable();

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getQuestions(quizId)
  {
    if (quizId)
    {
      return this.http.get(this.baseUrl + `api/question/${quizId}`);
    } else{
      return this.getAllQuestions();
    }
    
  }

  getAllQuestions()
  {
    return this.http.get(this.baseUrl + `api/question`);
  }

  postQuestion(question){
    this.http.post(this.baseUrl + 'api/question', question).subscribe(result => {
      console.log(result);
    });
  }

  putQuestion(question){
    this.http.put(this.baseUrl + `api/question/${question.id}`, question).subscribe(result => {
      console.log(result);
    });
  }

  selectQuestion(question){
    this.selectedQuestion.next(question);
  }
}
