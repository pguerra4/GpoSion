import { Component, OnInit } from "@angular/core";
import { User } from "../_models/user";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { AlertifyService } from "../_services/alertify.service";
import { Router, ActivatedRoute } from "@angular/router";
import { UserProfileService } from "../_services/user-profile.service";

@Component({
  selector: "app-user-profile-edit",
  templateUrl: "./user-profile-edit.component.html",
  styleUrls: ["./user-profile-edit.component.css"],
})
export class UserProfileEditComponent implements OnInit {
  user: User;
  userForm: FormGroup;

  constructor(
    private userService: UserProfileService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      // tslint:disable-next-line: no-string-literal
      this.user = data["user"];
      this.createUserForm();
    });
    //this.loadUser(this.route.snapshot.params["id"]);
  }

  createUserForm() {
    this.userForm = this.fb.group({
      id: [this.user.id, Validators.required],
      nombre: [this.user.nombre],
      paterno: [this.user.paterno],
      materno: [this.user.materno],
      eMail: [this.user.eMail],
    });
  }

  // loadUser(id: string) {
  //   this.userService.getUser(id).subscribe(
  //     (res: User) => {
  //       this.user = res;
  //       this.createUserForm();
  //     },
  //     error => {
  //       this.alertify.error(error);
  //     }
  //   );
  // }

  editUser() {
    this.user = Object.assign({}, this.userForm.value);

    this.userService
      .editUser(this.route.snapshot.params["id"], this.user)
      .subscribe(
        (res: User) => {
          this.alertify.success("Guardado");
          this.router.navigate(["home"]);
        },
        (error) => {
          this.alertify.error(error);
        }
      );
  }
}
