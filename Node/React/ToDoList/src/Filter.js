import React, { Component } from 'react';

export class Filters extends Component {
  render() {
    return (
      <div>
        <input type='button' value='All' onClick={this.props.filterHandler}/>
        <input type='button' value='Complete' onClick={this.props.filterHandler}/>
        <input type='button' value='Pending' onClick={this.props.filterHandler}/>
      </div>
    );
  }
}
