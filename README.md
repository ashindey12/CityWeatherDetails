# CityWeatherDetails
Instructions to run Application locally
To open solution CityWeatherDetails it consist of below 3 projects 
web-App frontend Application - CityWeatherDetails
web-API backend Application - WeatherDetailsAPI
Sample Nunit Web Api solution - WeaherDetailsAPINUnit

Step 1 - open web-App application in VS code
Step 2 - run npm install
Step 3 - run ng serve -o localhost:4200
Step 4 - open web-API solution in VS 2019/2022
Step 5 - set WeatherDetailsAPI as startup project
Step 6 - run the solution, https://localhost:7116;http://localhost:5116 swagger page will open with https

To run from VS 2019/2022 entirely please followbelow steps

Step 1 - set the multiple project start up by moving web-Api application to the top in sequence
Step 2 - Go to the launchSettings.json file in your ASP.NET Core project (in the Properties folder). Get the port number from the applicationUrl property.

Step 3 - If there are multiple applicationUrl properties, look for one using an https endpoint. It should look similar to https://localhost:7049.

Step 4 - Then, go to the proxy.conf.js file for your Angular project (look in the src folder). Update the target property to match the applicationUrl property in launchSettings.json
