import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ChangePassword } from '../_models/change-password';
import { User } from '../_models/user';
import { AdminService } from '../_services/admin.service';
import { AlertifyService } from '../_services/alertify.service';
import { CustomValidators } from '../_validators/custom-validators';
import { UserProfileService } from '../_services/user-profile.service';

@Component({
  selector: 'app-change-password-admin',
  templateUrl: './change-password-admin.component.html',
  styleUrls: ['./change-password-admin.component.scss']
})
export class ChangePasswordAdminComponent implements OnInit {
  user: User;
  userToChange: ChangePassword;
  userForm: FormGroup;

  constructor(
    private userService: UserProfileService,
    private adminService: AdminService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.loadUser(this.route.snapshot.params["id"]);
  }

  createUserForm() {
    this.userForm = this.fb.group(
      {
        id: [this.user.id],
        newPassword: [
          "**********",
          [
            Validators.required,
            Validators.minLength(8),
            Validators.maxLength(50),
            CustomValidators.patternValidator(/\d/, { hasNumber: true }),
            // 3. check whether the entered password has upper case letter
            CustomValidators.patternValidator(/[A-Z]/, { hasCapitalCase: true })
          ]
        ],
        confirmPassword: ["**********", Validators.required]
      },
      { validator: this.passwordMatchValidator }
    );
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get("newPassword").value === g.get("confirmPassword").value
      ? null
      : { mismatch: true };
  }

  loadUser(id: string) {
    this.userService.getUser(id).subscribe(
      (res: User) => {
        this.user = res;
        this.createUserForm();
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  changePassword() {
    this.userToChange = Object.assign({}, this.userForm.value);

    this.adminService
      .changePassword(this.route.snapshot.params["id"], this.userToChange)
      .subscribe(
        res => {
          this.alertify.success("Password actualizado");
          this.router.navigate(["admin"]);
        },
        error => {
          this.alertify.error(error);
          console.log(error);
        }
      );
  }

}
