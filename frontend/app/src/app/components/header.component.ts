import { Component } from "@angular/core";

@Component({
    standalone: true,
    selector: 'app-header',
    template: `
        <header class="p-4 border-2 border-black">
            <h1 class="text-3xl text-primary font-mono">Intro to Programming</h1>
            <p>Sample Full-Stack Application For Class!!!</p>
        </header> 
    `
})
export class HeaderComponent {};