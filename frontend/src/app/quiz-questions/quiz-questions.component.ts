import { Component, OnInit } from '@angular/core';
import { IQuestions } from '../models/questions';
import { QuizQuestionsService } from '../services/quiz-questions.service';
import { FormControl } from '@angular/forms';
import { AnswersService } from '../services/answers.service';
import { IAnswer } from '../models/IAnswer';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-quiz-questions',
  standalone: false,
  templateUrl: './quiz-questions.component.html',
  styleUrl: './quiz-questions.component.css'
})
export class QuizQuestionsComponent implements OnInit{
  questions: IQuestions[] = [];
  answerControls: { [key: number]: FormControl } = {};

  constructor(private quizQuestionsService: QuizQuestionsService, private answerService: AnswersService, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.GetQuestions();
  }

  GetQuestions(){
    this.quizQuestionsService.GetQuestions().subscribe({
      next: result => {
        this.questions = result;
        this.initializeFormControls();
      },
      error: error => console.log(error)
    });
  }

  initializeFormControls() {
    this.questions.forEach(question => {
      this.answerControls[question.id] = new FormControl('');
    });
  }

  onSubmit(questionId: number) {
    let text = this.answerControls[questionId].value;
    const answer: IAnswer = {userAnswer: text, questionId: questionId}
    this.answerService.postAnswer(answer).subscribe({
      next: () => this.toastr.success("Successfully Submitted"),
      error: error => this.toastr.error(error.error)
    });
  }

}
