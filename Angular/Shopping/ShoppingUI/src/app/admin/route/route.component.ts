import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';

@Component({
  selector: 'pm-route',
  templateUrl: './route.component.html',
  styleUrls: ['./route.component.css']
})
export class RouteComponent implements OnInit {
  value : string;
  values : string;
  result : string;
  bool: boolean;
  options: FormGroup;
  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.value = "";
    this.values = "";
    this.bool = true;
    this.options = this.fb.group({
      hideRequired: false,
      floatLabel: 'auto',
    });
  }

onChangeText(){
  debugger;
  this.result = this.value + this.values;
}

  public arr: Array<object> = [
    {texts: 'Sentence 1', random: 'Data'},
    {texts: 'Sentence 2', random: 'Data'},
    {texts: 'Sentence 3', random: 'Data'},
    {texts: 'Sentence 4', random: 'Data'},
    {texts: 'Sentence 2', random: 'Data'},
    {texts: 'Sentence 3', random: 'Data'},
    {texts: 'Sentence 4', random: 'Data'},
  ];

  public arr1: Array<object> = [
    {ids: 1, texts: 'Sentenghjghjce 1', random: 'Datadsfgdf'},
    {ids: 1, texts: 'Sentence 1', random: 'Datadsfgdf'},
    {ids: 1, texts: 'Sentence 1', random: 'Datadsfgdf'},
    {ids: 1, texts: 'fghj 1', random: 'Datadsfgdf'},
    {ids: 1, texts: 'Sentence 1', random: 'Datadsfgdf'},
    {ids: 1, texts: 'Sentence 1', random: 'Random'},
    {ids: 4, texts: 'Sentence 4', random: 'Data'},
  ];
}
