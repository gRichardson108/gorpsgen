import { Injectable } from '@angular/core';
import { QuestionComponent } from './question/question.component';

@Injectable()
export class CharacterGeneratorService {

  constructor() { }

  calculateScore(questions) {
    var combatTotal = 0;
    var magicTotal = 0;
    var stealthTotal = 0;
    var totalResponses = 0;
    questions.array.forEach(q => {
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
      "combatTotal" : combatTotal,
      "magicTotal" : magicTotal,
      "stealthTotal" : stealthTotal,
      "totalResponses" : totalResponses
    }
  }
}
