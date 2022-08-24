import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from '@angular/common';
import { WeatherDetailsComponent } from "./weather-details.component";
import { WeatherDetailsRoutingModule } from "./weather-details-routing.module";
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [
        WeatherDetailsComponent
    ],
    imports: [
        HttpClientModule,
        WeatherDetailsRoutingModule,
        ReactiveFormsModule,
        FormsModule,
        CommonModule

    ],
})
export class WeatherDetailsModule { }