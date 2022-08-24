import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICityWeatherDetails } from '../model/weather-details-info';

@Injectable({
    providedIn: 'root'
  })
  export class WeatherDetailsService {
  
  
    constructor(private _http: HttpClient) { }

    public getCityWeatherDetails(cityname: string): Observable<ICityWeatherDetails> {
  
       const url = environment.apiEndpoint +'WeatherForecast/getweatherforecastbycity/';
         return this._http
         .get(url + cityname);
       
      }
  }