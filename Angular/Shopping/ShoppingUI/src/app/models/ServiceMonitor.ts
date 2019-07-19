export class ServiceMonitor {
  ID: number;
  Name: string;
  Status: HealthStatus;
  RunTime: Date;
}

export enum HealthStatus {
  Healthy = 1,
  UnHealthy = 2
}