import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

@Injectable()
export class QuizSubmissionService {

  private selectedQuiz = new Subject<any>();
  quizSelected = this.selectedQuiz.asObservable();

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getQuizzes(){
    return this.http.get(this.baseUrl + 'api/quiz');
  }

  postQuiz(quiz){
    this.http.post(this.baseUrl + 'api/quiz', quiz).subscribe(result => {
      console.log(result);
    });
  }

  putQuiz(quiz){
    this.http.put(this.baseUrl + `api/quiz/${quiz.id}`, quiz).subscribe(result => {
      console.log(result);
    });
  }

  selectQuiz(quiz){
    console.log(quiz);
    this.selectedQuiz.next(quiz);
  }
}
