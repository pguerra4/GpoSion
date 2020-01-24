import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { User } from "src/app/_models/user";
import { AdminService } from "src/app/_services/admin.service";
import { AlertifyService } from "src/app/_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-user-edit",
  templateUrl: "./user-edit.component.html",
  styleUrls: ["./user-edit.component.css"]
})
export class UserEditComponent implements OnInit {
  user: User;
  userForm: FormGroup;
  selectedRoles: any[] = [{}];
  roles: string[];

  constructor(
    private adminService: AdminService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.user = data["user"];
      this.getRoles();
      this.createUserForm();
    });
  }

  createUserForm() {
    this.userForm = this.fb.group({
      id: [this.user.id, Validators.required],
      nombre: [this.user.nombre],
      paterno: [this.user.paterno],
      materno: [this.user.materno]
    });
  }

  // passwordMatchValidator(g: FormGroup) {
  //   return g.get("password").value === g.get("confirmPassword").value
  //     ? null
  //     : { mismatch: true };
  // }

  getRoles() {
    this.adminService.getRoles().subscribe(
      (res: string[]) => {
        this.roles = res;
        this.getRolesArray();
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  getRolesArray() {
    this.selectedRoles.pop();
    for (let i = 0; i < this.roles.length; i++) {
      if (this.user.roles.includes(this.roles[i])) {
        this.selectedRoles.push({
          name: this.roles[i],
          value: this.roles[i],
          checked: true
        });
      } else {
        this.selectedRoles.push({
          name: this.roles[i],
          value: this.roles[i],
          checked: false
        });
      }
    }
  }

  editUser() {
    this.user = Object.assign({}, this.userForm.value);
    const nuevosRoles = this.selectedRoles
      .filter(el => el.checked === true)
      .map(el => el.name);
    this.user.roles = nuevosRoles;
    this.adminService
      .editUser(this.route.snapshot.params["id"], this.user)
      .subscribe(
        (res: User) => {
          this.alertify.success("Guardado");
          this.router.navigate(["admin"]);
        },
        error => {
          this.alertify.error(error);
        }
      );
  }
}
