import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EntryComponent } from './components/entry/entry.component';
import { ListComponent } from './components/list/list.component';
import { TodoListItemModel, TodoListEntryModel } from './models';

@Component({
  selector: 'app-todos',
  standalone: true,
  imports: [CommonModule, EntryComponent, ListComponent],
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.css'],
})
export class TodosComponent {
  todoList: TodoListItemModel[] = [];
  addItem(candidate: TodoListEntryModel) {
    const newItem: TodoListItemModel = {
      id: '99',
      description: candidate.description,
      status: 'Later',
    };
    this.todoList = [newItem, ...this.todoList];
  }
}
