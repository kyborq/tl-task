import { Component, OnInit } from '@angular/core';

class TodoItem {
  name: string;
  done: boolean;
  constructor (name: string) {
    this.name = name;
    this.done = false;
  }
}

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {

  newTodo = "";
  todos: TodoItem[] = [];

  constructor() { }

  ngOnInit(): void {
  }

  addTaskHandler() {
    this.todos.push(
      new TodoItem(this.newTodo)
    );
    this.newTodo = '';
  }

}
