import { Injectable } from '@angular/core';
import { HealthStatus, ServiceMonitor } from '../models/ServiceMonitor';

@Injectable({
  providedIn: 'root'
})
export class ServiceMonitorService {

  constructor() { }

  getServices(): ServiceMonitor[] {
    return [
      {
        ID: Math.random(),
        Name: "Sample App 1",
        Status: HealthStatus.Healthy,
        RunTime: new Date()
      },
      {
        ID: Math.random(),
        Name: "Sample App 2",
        Status: HealthStatus.Healthy,
        RunTime: new Date()
      },
      {
        ID: Math.random(),
        Name: "Sample App 3",
        Status: HealthStatus.Healthy,
        RunTime: new Date()
      },
      {
        ID: Math.random(),
        Name: "Sample App 4",
        Status: HealthStatus.Healthy,
        RunTime: new Date()
      },
      {
        ID: Math.random(),
        Name: "Sample App 5",
        Status: HealthStatus.Healthy,
        RunTime: new Date()
      },
    ];
  }
}
