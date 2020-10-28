import { Component, OnInit, Input } from '@angular/core';
import { AdminService } from './admin.service';
import { AccountRole } from './account';
import { Account } from './account'
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})

export class AdminComponent implements OnInit {

  form: FormGroup;
  accounts: Account[];
  role: AccountRole;

  @Input()
  editMode: boolean[];

  addForm = new FormGroup({
    Email: new FormControl('', [Validators.required, Validators.email]),
    Password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    Role: new FormControl('', Validators.required),
  });

  constructor(private adminService: AdminService) {
    this.accounts = [];
    this.editMode = [];
  }

  ngOnInit() {
    this.getAllUsers();
    this.initEditMode();
  }

  initEditMode() {
    for (var i = 0; i < length; i++) {
      this.editMode.push(false);
    }
  }

  onEdit(i: number, isEdit: boolean) {
    this.editMode[i] = isEdit;
  }

  getAllUsers(){
    this.adminService.get().subscribe(data => {
      this.accounts = data.map(x =>
        ({
          email: x.email,
          id: x.id,
          password: x.password,
          role: x.role as AccountRole
        }));
    },
      error => {
        alert(error.status === 403 ?
          "Access Denied You don’t have permission to access" :
          "BadRequest")
      });
  }

  postNewAccount() {
    this.adminService.post(this.addForm.value)
      .subscribe(data => {
      alert(data);
      this.getAllUsers();
      },
        error => {
          alert(error.status === 403 ?
            "Access Denied You don’t have permission to access" :
            "BadRequest")
        });
  }

  putEditedUser(i:number, account:Account) {
    this.onEdit(i, false);
    this.adminService.put(account)
      .subscribe(data => {
      alert(data);
      this.getAllUsers();
      },
        error => {
          alert(error.status === 403 ?
            "Access Denied You don’t have permission to access" :
            "BadRequest")
        });
  }

  deleteUser(id: number) {
    this.adminService.delete(id)
      .subscribe(data => {
      alert(data);
      this.getAllUsers();
      },
        error => {
          alert(error.status === 403 ?
            "Access Denied You don’t have permission to access" :
            "BadRequest")
        })
  }

  getRoleName(enumValue: number): string {
    return AccountRole[enumValue];
  }
}
