import { Component, OnInit } from "@angular/core";
import { User } from "src/app/_models/user";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { AdminService } from "src/app/_services/admin.service";
import { AlertifyService } from "src/app/_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";
import { CustomValidators } from "src/app/_validators/custom-validators";

@Component({
  selector: "app-user-register",
  templateUrl: "./user-register.component.html",
  styleUrls: ["./user-register.component.css"]
})
export class UserRegisterComponent implements OnInit {
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
    this.getRoles();
    this.createUserForm();
  }

  createUserForm() {
    this.userForm = this.fb.group(
      {
        userName: ["", Validators.required],
        nombre: [""],
        paterno: [""],
        materno: [""],
        password: [
          "",
          [
            Validators.required,
            Validators.minLength(8),
            Validators.maxLength(50),
            CustomValidators.patternValidator(/\d/, { hasNumber: true }),
            // 3. check whether the entered password has upper case letter
            CustomValidators.patternValidator(/[A-Z]/, { hasCapitalCase: true })
          ]
        ],
        confirmPassword: ["", Validators.required]
      },
      { validator: this.passwordMatchValidator }
    );
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get("password").value === g.get("confirmPassword").value
      ? null
      : { mismatch: true };
  }

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
      this.selectedRoles.push({
        name: this.roles[i],
        value: this.roles[i],
        checked: false
      });
    }
  }

  addUser() {
    this.user = Object.assign({}, this.userForm.value);
    const nuevosRoles = this.selectedRoles
      .filter(el => el.checked === true)
      .map(el => el.name);
    this.user.roles = nuevosRoles;
    this.adminService.registerUser(this.user).subscribe(
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
