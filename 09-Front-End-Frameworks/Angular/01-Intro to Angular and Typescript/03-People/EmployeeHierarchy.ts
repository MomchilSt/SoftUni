abstract class Employee {
    public name: string;
    public age: number;
    public salary: number;
    public tasks: Array<string>;
  
    constructor(name: string, age: number) {
      this.name = name;
      this.age = age;
      this.salary = 0;
      this.tasks = [];
    }
  
    public getSalary(): number {
      return this.salary;
    }
  
    public work(): void {
      const currentTask = this.tasks[0];
      this.tasks.shift();
      this.tasks.push(currentTask);
      console.log(this.name + currentTask);
    }
  
    public collectSalary(): void {
      console.log(`${this.name} received ${this.getSalary()} this month.`);
    }
  }
  
  export class Junior extends Employee {
    constructor(name: string, age: number) {
      super(name, age);
      this.tasks.push(" is working on a simple task");
    }
  }
  
  export class Senior extends Employee {
    constructor(name: string, age: number) {
      super(name, age);
      this.tasks.push(" is working on a complicated task.");
      this.tasks.push(" is taking time off work.");
      this.tasks.push(" is supervising junior workers");
    }
  }
  
  export class Manager extends Employee {
    public divident: number;
  
    constructor(name: string, age: number) {
      super(name, age);
      this.divident = 0;
      this.tasks.push(" scheduled a meeting.");
      this.tasks.push(" is preparing a quarterly meeting.");
    }
  
    public getSalary(): number {
      return this.salary + this.divident;
    }
  }