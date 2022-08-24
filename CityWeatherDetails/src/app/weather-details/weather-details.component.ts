import { Component, OnInit } from '@angular/core';
import { WeatherDetailsService } from '../services/weatherdetails.service';
import { ICityWeatherDetails } from '../model/weather-details-info';

@Component({
  selector: 'app-weather-details',
  templateUrl: './weather-details.component.html',
  styleUrls: ['./weather-details.component.css']
})
// add pipe to format number to 2 or 3 digit decimal
export class WeatherDetailsComponent implements OnInit {
  city ='';
  showDetails = false;
  showTemp_F = false;
  cityweatherdetails: ICityWeatherDetails = {} as ICityWeatherDetails;
  constructor(private weatherdetailservice: WeatherDetailsService) { }

  ngOnInit(): void {
  }

  GetWeatherdetails(): void {
    if(this.city){
      this.weatherdetailservice.getCityWeatherDetails(this.city).subscribe((res: ICityWeatherDetails) => {
        if(res){
          this.showTemp_F = false;
          this.showDetails = true;
          this.cityweatherdetails = res;
        }
    }); 
    } else {
      this.showTemp_F = false;
      this.showDetails = false;
    }
      
}

ShowInFarh(): void {
  this.showTemp_F = true;
}

}
