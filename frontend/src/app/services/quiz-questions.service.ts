import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IQuestions } from '../models/questions';

@Injectable({
  providedIn: 'root'
})
export class QuizQuestionsService {

  constructor(private http: HttpClient) { }

  GetQuestions(){
    return this.http.get<IQuestions>("https://localhost:5001/api/QuizQuestion");
  }
}
