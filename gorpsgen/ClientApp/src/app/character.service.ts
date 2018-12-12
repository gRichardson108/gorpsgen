import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { QuestionComponent } from './question/question.component';
import { Observable } from 'rxjs';
import { of } from 'rxjs/observable/of';
import { Character } from './models/character';

@Injectable()
export class CharacterService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  calculateScore(questions) {
    var combatTotal = 0;
    var magicTotal = 0;
    var stealthTotal = 0;
    var totalResponses = 0;
    questions.forEach(q => {
      if (q.selectedAnswer) {
        totalResponses++;
        switch (q.selectedAnswer) {
          case q.combatAnswer:
            combatTotal++;
            break;
          case q.magicAnswer:
            magicTotal++;
            break;
          case q.stealthAnswer:
            stealthTotal++;
            break;
        }
      }
    });
    return {
      "RatioCombat" : combatTotal,
      "RatioMagic" : magicTotal,
      "RatioStealth" : stealthTotal,
      "QuizId" : null
    }
  }

  submitQuizResponse(quizResponse) : Observable<Character>
  {
    return this.http.post<Character>(this.baseUrl + 'api/quiz/QuizResponse', quizResponse);
  }

  getCharacter(id: string) : Observable<Character>
  {
    return this.http.get<Character>(this.baseUrl + `api/characters/${id}`);
  }
}
