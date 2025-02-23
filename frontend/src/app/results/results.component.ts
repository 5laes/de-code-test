import { Component, OnInit } from '@angular/core';
import { AnswersService } from '../services/answers.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-results',
  standalone: false,
  templateUrl: './results.component.html',
  styleUrl: './results.component.css'
})
export class ResultsComponent implements OnInit{
  answers: any;

  constructor(private answerService: AnswersService, private toastr: ToastrService) {}

  ngOnInit(): void {
    this.getAnswers();
  }

  getAnswers() {
    this.answerService.getAnswers().subscribe({
      next: result => this.answers = result
    })
  }

  deleteAnswers() {
    this.answerService.deleteAnswers().subscribe({
      next: () => {
        this.toastr.success("Successfully Deleted Answers");
        this.answers = undefined;
      },
      error: error => this.toastr.error(error.error)
    })
  }

}
