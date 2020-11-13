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

  public messageFrom = new FormGroup({
    msg: new FormControl("")
  });

  message = this.messageFrom.get('message');

  public messages: Message[] = [];
  public error = "";
  public editId: number;
  public editedValue: string;

  constructor(private dashService: DashboardService) { }


  ngOnInit(): void {
    this.dashService.get()
    .subscribe(data => {
      this.error = "";
      this.messages = data;
    }, err => {
      this.error = "Error get http";
    })
  }

  onUpdate(id: number, event: any) {
    this.editId = id;
    this.editedValue = this.messages
    .find(message => message.id === id).msg;
    event.target.innerText = "Save";
  }

  update(id: number, event: any) {
    var msg: Message = {
      id: id,
      msg: this.editedValue
    }
    this.dashService.put(msg)
    .subscribe(data => {
      this.messages.find(message => message.id === id).msg = data.msg;
      this.error = "";
      err => {
        this.error = "Error put http";
      }
    });
    this.editId = null;
    event.target.textContent = "Update";
  }

  delete(id: number) {
    this.dashService.delete(id)
    .subscribe(() => {
      this.error = "";
      err => {
        this.error = "Error delete http";
      }
    });
    let index = this.messages.findIndex(msg => msg.id === id);
    this.messages.splice(index, 1);
  }

  add() {
    console.log(this.messageFrom.value);
    this.dashService.post(this.messageFrom.value)
    .subscribe(data => {
      this.messages.push(data);
      this.error = "";
    }, err => {
      this.error = "Error post http";
    });
    this.messageFrom.reset();
  }
}