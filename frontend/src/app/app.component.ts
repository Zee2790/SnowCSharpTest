import { Component, OnInit } from '@angular/core';
import Chart from 'chart.js';
import { ApisService } from './services/apis.service';
import { log } from 'util';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private _apiService: ApisService) { }
  bar_chart = [];
  selectedFile: File = null;

  data;
  labels;
  colors;

  alert = {
    message: '',
    class: ''
  };

  ngOnInit(): void {
    this.inintChart();
  }

  /*   processFile() {

      this._apiService.processFile()
        .subscribe((res) => {
          console.log('Response data:', res);

        }, (err) => {
          console.log('Response data:', err);

        });

    } */


  onFileChanged(event) {
    console.log('file changing');

    this.selectedFile = event.target.files[0];

  }

  onProcess() {

    const uploadData = new FormData();
    uploadData.append('myFile', this.selectedFile, this.selectedFile.name);


    this._apiService.processFile(uploadData)
      .subscribe((res) => {
        this.alert.class = 'alert alert-success';
        this.alert.message = 'File Processed Successfully!';

        this.labels = res.map((d) => {
          return d.BarCode;
        });

        this.data = res.map((d) => {
          return d.Size;
        });

        this.colors = res.map((d) => {
          return d.Color;
        });

        this.inintChart();

        console.log('Labels: ', this.labels);
        console.log('data: ', this.data);
        console.log('colors: ', this.colors);

        //  this.data = res;

        // console.log('this.data : ', this.data);



      }, (err) => {
        this.labels = this.data = null;
        this.inintChart();

        this.alert.class = 'alert alert-danger';
        this.alert.message = err.error.Message;
        console.log('file process error: ', err);
        console.log('file process error: ', err.error.Message);

      });



  }

  inintChart() {
    this.bar_chart = new Chart('barChart', {
      type: 'bar',
      data: {
        labels: this.labels,
        datasets: [{
          label: '# of Votes',
          data: this.data,
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)',
            'rgba(255, 159, 64, 0.2)'
          ],
          borderColor: [
            'rgba(255,99,132,1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)'
          ],
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          yAxes: [{
            ticks: {
              beginAtZero: true
            }
          }]
        }
      }
    });

  }


}
