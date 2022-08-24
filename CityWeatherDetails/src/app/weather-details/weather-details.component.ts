import { Component, OnInit } from '@angular/core';
import { WeatherDetailsService } from '../services/weatherdetails.service';
import { ICityWeatherDetails } from '../model/weather-details-info';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';

@Component({
  selector: 'app-weather-details',
  templateUrl: './weather-details.component.html',
  styleUrls: ['./weather-details.component.css']
})
// TODO - add pipe to format number to 2 or 3 digit decimal

export class WeatherDetailsComponent implements OnInit {
  city ='';
  showDetails = false;
  showTemp_F = false;
  cityweatherdetails: ICityWeatherDetails = {} as ICityWeatherDetails;
  form: FormGroup = this.formBuilder.group(
    {
      fullname: ['', Validators.required]
    });
  constructor(private weatherdetailservice: WeatherDetailsService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    
  }
  /*
  To get controls within formgroup
  */
  // get formControl(): { [key: string]: AbstractControl } {
  //   return this.form.controls;
  // }

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
