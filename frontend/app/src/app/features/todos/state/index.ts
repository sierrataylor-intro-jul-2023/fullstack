import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
} from '@ngrx/store';
import * as fromTodoList from './todo-list.reducer';
import { TodoListItemModel } from '../models';
export const FEATURE_NAME = 'todosFeature';

export interface TodosState {
  todoList: fromTodoList.TodoListState;
}

export const reducers: ActionReducerMap<TodosState> = {
  todoList: fromTodoList.reducer,
};

// 1. feature selector
const selectFeature = createFeatureSelector<TodosState>(FEATURE_NAME);

// 2. selector per branch of the feature
const selectTodoListBranch = createSelector(selectFeature, (f) => f.todoList);

// 3. helper (will return a todo list item array)
const { selectAll: selectTodoListItemArray } =
  fromTodoList.adapter.getSelectors(selectTodoListBranch);

// 4. what the component needs
//TODO: one that returns a TodoListItemModel[]
export const selectTodoListModel = createSelector(
  selectTodoListItemArray,
  (items) => items as TodoListItemModel[]
);
