import { Component, Input, OnInit } from '@angular/core';
import { getKeys, readProp } from '../util.object';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})

export class TableComponent implements OnInit {

  constructor() { }
  _headers: string[];

  @Input('data') data: Array<object>;

  ngOnInit() {
    this._headers = getKeys(this.data[0]);
  }

  selectedItem: object = null;

  onSelect(item: object): void {
    this.selectedItem = item;
  }

  readProps(item:object): string[] {
    let columnData:string[] = [];

    this._headers.forEach(element => {
      columnData.push(readProp(item, element));
    });

    return columnData;
  }
}
