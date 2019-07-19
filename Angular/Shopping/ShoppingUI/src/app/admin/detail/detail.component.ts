import { Component, OnInit } from '@angular/core';
import { ServiceMonitor } from 'src/app/models/ServiceMonitor';
import { ServiceMonitorService } from 'src/app/service/servicemonitor.service';

@Component({
  selector: 'pm-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {

  _service:ServiceMonitorService;
  constructor(private service:ServiceMonitorService) { 
    this._service = service; 
  }

  _services: ServiceMonitor[];

  ngOnInit() {
    this._services = this._service.getServices();
    console.log(JSON.stringify(this._services));
  }

}
