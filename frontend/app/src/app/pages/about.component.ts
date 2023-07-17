import { Component } from "@angular/core";
import { HeaderComponent } from "../components/header.component";

@Component({
    standalone: true,
    selector: 'app-about',
    template: `
        <section class="prose">
            <h2>this is the about section</h2>
        </section>
    `,
    imports: [HeaderComponent]
})
export class AboutComponent {};