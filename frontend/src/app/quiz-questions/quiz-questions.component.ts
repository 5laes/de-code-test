import { Component, OnInit } from '@angular/core';
import { IQuestions } from '../models/questions';
import { QuizQuestionsService } from '../services/quiz-questions.service';

@Component({
  selector: 'app-quiz-questions',
  standalone: false,
  templateUrl: './quiz-questions.component.html',
  styleUrl: './quiz-questions.component.css'
})
export class QuizQuestionsComponent implements OnInit{
  questions : IQuestions;

  constructor(private quizQuestionsService: QuizQuestionsService) {}

  ngOnInit(): void {
    this.GetQuestions();
  }

  GetQuestions(){
    this.quizQuestionsService.GetQuestions().subscribe({
      next: result => {
        this.questions = result;
      },
      error: error => console.log(error)
    });
  }

}
