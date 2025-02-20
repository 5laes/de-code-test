import { Component, OnInit } from '@angular/core';
import { TestService } from '../services/test.service';

@Component({
  selector: 'app-test',
  standalone: false,
  templateUrl: './test.component.html',
  styleUrl: './test.component.css'
})
export class TestComponent implements OnInit{
  testString : string;

  constructor(private testService: TestService) { }

  ngOnInit(): void {
    this.getTest();
  }

  getTest(){
    this.testService.getTest().subscribe({
      next: result => this.testString = result.message,
      error: error => console.log(error)
    })
  }
}
