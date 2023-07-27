import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideState, provideStore } from '@ngrx/store';
import { reducers } from './state';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { provideEffects } from '@ngrx/effects';
import { todosRoutes } from './features/todos/todos.routes';
import * as fromCounterState from './features/counter/state';
import { ApplicationConfig } from '@angular/core';
export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideStore(reducers),
    provideState(fromCounterState.FEATURE_NAME, fromCounterState.reducers),
    provideEffects([]),
    provideStoreDevtools(),
  ],
};
