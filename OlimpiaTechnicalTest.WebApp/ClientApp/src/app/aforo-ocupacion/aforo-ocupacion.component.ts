import { Component, Input, OnInit } from '@angular/core';
import { ChartOptions, ChartType } from 'chart.js';
import { Label, SingleDataSet } from 'ng2-charts';
import { Aforo } from '../../obj/aforo';

@Component({
  selector: 'app-aforo-ocupacion-component',
  templateUrl: './aforo-ocupacion.component.html'
})
export class AforoOcupacionComponent implements OnInit {
  @Input() aforo: Aforo;
  public chartLabels: Label[] = ['Disponible', 'Cant. Aficionados'];
  public chartData: SingleDataSet = [[65, 35]];
  public chartType: ChartType = 'pie';
  public chartOptions: ChartOptions = {
    responsive: true,
    legend: {
      position: 'right',
    },
  }
  public chartColors = [
    {
      backgroundColor: ['rgba(59, 131, 189,0.8)', 'rgba(255, 0, 0,0.8)'],
    },
  ];

  constructor() { }

  ngOnInit(): void {
    this.chartData = [];
    let capacidadMaximaHabilitada = ((this.aforo.CapacidadTotal * this.aforo.Porcentajehabilitado) / 100);

    this.chartData.push(capacidadMaximaHabilitada - this.aforo.CantidadAficionados);
    this.chartData.push(this.aforo.CantidadAficionados);
  }

  public chartClicked({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }

  public chartHovered({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }
}
