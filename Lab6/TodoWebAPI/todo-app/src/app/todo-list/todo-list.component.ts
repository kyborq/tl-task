import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

class TodoItem {
  id: number;
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
  private _http: HttpClient;

  constructor(http: HttpClient) {
    this._http = http;
  }

  async ngOnInit(): Promise<void> {
    this.todos = await this._http.get<TodoItem[]>("/api/todo").toPromise();
  }

  async addTaskHandler() {
    let newTodo: TodoItem = new TodoItem(this.newTodo);
    let newTodoID: number = await this._http.post<number>("/api/todo", newTodo).toPromise();
    newTodo.id = newTodoID;
    this.todos.push(
      new TodoItem(this.newTodo)
      
      );
    this.newTodo = '';
  }

  async updateTodoHandler(todo: TodoItem) {
    await this._http.put(`/api/todo/${todo.id}`, todo).toPromise();
  }

}
