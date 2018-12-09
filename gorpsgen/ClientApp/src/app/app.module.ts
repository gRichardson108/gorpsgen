import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatCheckboxModule, MatInputModule, MatCardModule, MatListModule} from '@angular/material';
import { QuizSubmissionService } from './quiz-submission.service';
import { QuestionSubmissionService } from './question-submission.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { QuestionComponent } from './question/question.component';
import { QuestionListComponent } from './question-list/question-list.component';
import { QuizComponent } from './quiz/quiz.component';
import { QuizListComponent } from './quiz-list/quiz-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    QuestionComponent,
    QuestionListComponent,
    QuizComponent,
    QuizListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'question', component: QuestionComponent },
      { path: 'question-list', component: QuestionListComponent },
      { path: 'question-list/:quizId', component: QuestionListComponent },
      { path: 'quiz', component : QuizComponent },
      { path: 'quiz-list', component : QuizListComponent },
    ]),
    BrowserAnimationsModule,
    MatButtonModule, 
    MatCheckboxModule,
    MatInputModule,
    MatCardModule,
    MatListModule,
  ],
  providers: [QuizSubmissionService, QuestionSubmissionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
