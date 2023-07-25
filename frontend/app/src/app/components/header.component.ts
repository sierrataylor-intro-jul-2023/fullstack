import { Component, inject, signal } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectCounterCurrent } from '../features/counter/state';

@Component({
  standalone: true,
  selector: 'app-header',
  template: `
    <header class="p-4 border-2 border-black">
      <h1 class="text-3xl text-primary font-mono">Intro to Programming</h1>
      <p>
        Sample Full-Stack Application For Class!!!
        <small>Your Counter is at {{ current() }}</small>
      </p>
    </header>
  `,
})
export class HeaderComponent {
  current = inject(Store).selectSignal(selectCounterCurrent);
}
