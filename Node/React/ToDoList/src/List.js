import React, { Component } from 'react';
import './List.css';

export class List extends Component {

  createList = (elements) => {
    let list = []
    for (let i = 0; i < elements.length; i++) {
      list.push(
        <li onClick={this.props.updateFlag} task-id={elements[i].taskID} className={elements[i].isCompleted ? 'strike-out' : ''}>{elements[i].text}</li>
      );
    }
    return list
  }

  render() {
    return (
      <ul>
        {this.createList(this.props.list)}
      </ul>
    );
  }
}
