import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { IAnswer } from '../models/IAnswer';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AnswersService implements OnInit{

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  postAnswer(answer: IAnswer) {
    return this.http.post<IAnswer>("https://localhost:5001/api/QuizAnswer", answer);
  }

  getAnswers() {
    return this.http.get("https://localhost:5001/api/QuizAnswer");
  }

  deleteAnswers() {
    return this.http.delete("https://localhost:5001/api/QuizAnswer");
  }

}
