import React, { Component } from 'react';
import { Input } from './Input'
import { List } from './List'
import { Filters } from './Filter'
import './App.css';

class App extends Component {

  constructor(props) {
    super(props);
    this.state = { list: Array };
    this.state.list = [];
    this.input = '';
    this.count = 0;
    this.showList = [];
    this.choice = 'All';
    this.addToList = this.addToList.bind(this);
    this.handleChange = this.handleChange.bind(this);
    this.updateFlag = this.updateFlag.bind(this);
    this.filterList = this.filterList.bind(this);
    this.filterUpdate = this.filterUpdate.bind({ filterList: this.filterList });
  }

  render() {
    return (
      <div className="App">
        <header className="App-header">
          ToDo List
        </header>
        <div className='line-spacer'></div>
        <Input name='Add Task' handler={this.addToList} handleChange={this.handleChange} />
        <List list={this.showList} updateFlag={this.updateFlag} />
        <Filters filterHandler={this.filterUpdate} />
      </div>
    );
  }

  addToList() {
    var newArray = this.state.list.slice();
    console.log(this.count);
    var newElement = {
      text: this.input,
      isCompleted: false,
      taskID: this.count++
    };

    newArray.push(newElement);
    this.state.list = newArray;

    this.filterList(this.choice);
  }

  handleChange(e) {
    this.input = e.target.value;
  }

  updateFlag(e) {
    var newArray = this.state.list.slice();
    var targetTaskID = e.target.getAttribute('task-id');

    var element = newArray.filter((ele) => {
      return ele.taskID == targetTaskID;
    })[0];

    if (element.isCompleted) {
      element.isCompleted = false
    }
    else {
      element.isCompleted = true;
    }

    this.state.list = newArray;
    this.filterList(this.choice);
  }

  filterList(choice) {
    console.log(choice);
    switch (choice) {
      case "Complete":
        this.showList = this.state.list.filter(x => x.isCompleted);
        break;
      case "Pending":
        this.showList = this.state.list.filter(x => !x.isCompleted);
        break;
      default:
        this.showList = this.state.list;
        break;
    }

    this.choice = choice;
    this.setState({ list: this.state.list });
  }

  filterUpdate(e) {
    this.filterList(e.target.value);
  }
}

export default App;
