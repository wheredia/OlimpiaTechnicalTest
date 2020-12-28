import { Component, Input, OnInit } from '@angular/core';
import { ChartOptions, ChartType } from 'chart.js';
import { Label, SingleDataSet } from 'ng2-charts';
import { Aforo } from '../../obj/aforo';

@Component({
  selector: 'app-aforo-habilitado-component',
  templateUrl: './aforo-habilitado.component.html'
})
export class AforoHabilitadoComponent implements OnInit{
  @Input() aforo: Aforo;
  public chartLabels: Label[] = ['Restringido', 'Habilitada'];
  public chartData: SingleDataSet = [0, 0];
  public chartType: ChartType = 'pie';
  public chartOptions: ChartOptions = {
    responsive: true,
    legend: {
      position: 'right',
    },
  }
    public chartColors = [
    {
      backgroundColor: ['rgba(255, 165, 0,0.8)', 'rgba(60, 179, 113,0.8)'],
    },
  ];

  constructor() { }

  ngOnInit(): void {
    this.chartData = [];
    this.chartData.push(100 - this.aforo.Porcentajehabilitado);
    this.chartData.push(this.aforo.Porcentajehabilitado);
  }

  public chartClicked({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }

  public chartHovered({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }
}
