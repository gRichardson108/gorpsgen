import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class QuizSubmissionService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getQuestions(){
    return this.http.get(this.baseUrl + 'api/question');
  }

  postQuestion(question){
    this.http.post(this.baseUrl + 'api/question', question).subscribe(result => {
      console.log(result);
    });
  }
}
