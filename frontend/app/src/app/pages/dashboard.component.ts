import { Component } from "@angular/core";
import { HeaderComponent } from "../components/header.component";

@Component({
    standalone: true,
    selector: 'app-dashboard',
    templateUrl: "./dashboard.component.html",
    imports: [HeaderComponent]
})
export class DashboardComponent {};