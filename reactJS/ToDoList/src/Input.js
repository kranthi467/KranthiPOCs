import React, { Component } from 'react';

export class Input extends Component {
  
  render() {
    return (
      <React.Fragment>
        <input type='text' onChange={ this.props.handleChange }/>
        <input type='button' value={this.props.name} onClick={this.props.handler} />
      </React.Fragment>
    );
  }
}
