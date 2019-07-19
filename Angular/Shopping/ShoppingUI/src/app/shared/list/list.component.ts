import { Component, Input } from '@angular/core';
import { getKeys, readProp } from '../util.object';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})

export class ListComponent { 
  
  _selectedItem: object;

  constructor() { 
    this._selectedItem = null;
  }
  
  ngOnInit() {
  }

  @Input('list') list: Array<object>;

  onSelect(item: object): void {
    this._selectedItem = item;
  }

  getKeys = getKeys;
  readProp = readProp;
}
