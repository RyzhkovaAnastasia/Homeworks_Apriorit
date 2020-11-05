import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../services/dashboard.service';
import { Message } from '../interfaces/message-interface';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private dashService: DashboardService) { }

  public editId: number;
  public editedValue: string;

  public messageFrom = new FormGroup({
    message: new FormControl("", Validators.required)
  });

  message = this.messageFrom.get('message');

  public messages: Message[];
  public error = "";

  ngOnInit(): void {
    this.messages = [];
    this.dashService.get().subscribe(data => {
      this.error = "";
      this.messages = data;
    }, err => {
      this.error = "Error get http";
    })
  }

  setEditable(id: number, event: any) {
    this.editId = id;
    this.editedValue = this.messages.find(message => message.id === id).msg;
    event.target.innerText = "Save";
  }

  update(id: number, event: any) {
    var msg: Message = {
      id: id,
      msg: this.editedValue
    }
    this.dashService.put(msg).subscribe(data => {
      this.messages.find(message => message.id === id).msg = data.msg;
      this.error = "";
      err => {
        this.error = "Error put http";
      }
    });
    this.editId = null;
    event.target.textContent = "Edit";
  }

  delete(id: number) {
    this.dashService.delete(id).subscribe(() => {
      this.error = "";
      err => {
        this.error = "Error delete http";
      }
    });
    let index = this.messages.findIndex(msg => msg.id === id);
    this.messages.splice(index, 1);
  }

  add() {
    if(!this.messageFrom.valid) {
      this.messageFrom.markAllAsTouched();
      return;
    }
      
    var msg: Message = {
      id: 0,
      msg: this.message.value
    }
    
    this.dashService.post(msg).subscribe(data => {
      this.messages.push(data);
      this.error = "";
    }, err => {
      this.error = "Error post http";
    });
    this.messageFrom.reset();
  }
}