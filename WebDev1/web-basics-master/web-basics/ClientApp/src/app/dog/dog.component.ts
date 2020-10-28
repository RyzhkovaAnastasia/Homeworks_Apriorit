import { Component, OnInit } from '@angular/core';
import { DogService } from './dog.service';
import { Dog } from './dog';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-dog',
  templateUrl: './dog.component.html',
  styleUrls: ['./dog.component.css']
})
export class DogComponent implements OnInit {

  constructor(private dogService: DogService) { }

  dogs: Dog[];

  dogForm = new FormGroup({
    Name: new FormControl('', [Validators.required, Validators.minLength(2)]),
    Age: new FormControl('', Validators.required),
  });

  ngOnInit() {
    this.getAllDogs();
  }

  getAllDogs() {
    this.dogService.get().subscribe(data => {
      this.dogs = data;
    });
  }

  onSubmit() {
    this.dogService.addDog(this.dogForm.value)
      .subscribe(val => {
        alert(val.toString());
        this.getAllDogs();
      });
  }
}
