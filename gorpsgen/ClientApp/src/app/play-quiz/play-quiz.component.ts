import { Component, OnInit } from '@angular/core';
import { QuizSubmissionService } from '../quiz-submission.service';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionSubmissionService } from '../question-submission.service';
import { CharacterService } from '../character.service';

@Component({
  selector: 'app-play-quiz',
  templateUrl: './play-quiz.component.html',
  styleUrls: ['./play-quiz.component.css']
})
export class PlayQuizComponent implements OnInit {

  questions;
  quizId;
  step = 0;
  maxSteps = 0;
  previousExists = false;
  nextExists = false;

  constructor(private quizapi: QuizSubmissionService,
    private questionapi: QuestionSubmissionService, 
    private chargenapi: CharacterService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.quizId = this.route.snapshot.paramMap.get('quizId');
    console.log("QuizID: " + this.quizId);
    this.questionapi.getQuestions(this.quizId).subscribe(res => {
      this.questions = res;
      this.questions.forEach(q => {
        q.answers = [
          q.combatAnswer,
          q.magicAnswer,
          q.stealthAnswer
        ]
      });
      this.maxSteps = this.questions.length;
      this.checkBoundaries()
    });
  }

  checkBoundaries() {
    this.previousExists = (this.step > 0);
    this.nextExists = (this.step < this.maxSteps);
  }

  setStep(index: number){
    this.step = index;
    this.checkBoundaries()
  }

  nextStep() {
    this.step++;
    this.checkBoundaries()
  }

  prevStep() {
    this.step--;
    this.checkBoundaries()
  }

  finished() {
    var score = this.chargenapi.calculateScore(this.questions);
    score.QuizId = this.quizId;
    this.chargenapi.submitQuizResponse(score).subscribe(result => {
      this.router.navigate(['/characters', result.id]);
    });
  }

}
