import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuizChargenComponent } from './quiz-chargen.component';

describe('QuizChargenComponent', () => {
  let component: QuizChargenComponent;
  let fixture: ComponentFixture<QuizChargenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuizChargenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuizChargenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
