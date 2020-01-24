import { Component, OnInit } from "@angular/core";
import { User } from "src/app/_models/user";
import { AdminService } from "../../_services/admin.service";
import { AlertifyService } from "../../_services/alertify.service";

@Component({
  selector: "app-admin-panel",
  templateUrl: "./admin-panel.component.html",
  styleUrls: ["./admin-panel.component.css"]
})
export class AdminPanelComponent implements OnInit {
  users: User[];
  searchText = "";

  constructor(
    private adminService: AdminService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.getUsersWithRoles();
  }

  getUsersWithRoles() {
    this.adminService.getUsersWithRoles().subscribe(
      (users: User[]) => {
        this.users = users;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }

  deleteUser(id: string) {
    this.alertify.confirm("¿Desea borrar al usuario?", () => {
      this.adminService.deleteUser(id).subscribe(
        () => {
          this.users.splice(
            this.users.findIndex(u => u.id === id),
            1
          );
          this.getUsersWithRoles();
          this.alertify.success("Usuario borrado");
        },
        error => {
          this.alertify.error("Fallo al borrar al usuario:" + error);
        }
      );
    });
  }
}
