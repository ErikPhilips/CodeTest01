# Coding Test

Create a .NET Web API that takes ZIP-code as a parameter, then outputs city name, current temperature, time zone, and general elevation at the location with a user-friendly message. 

For example, “At the location $CITY_NAME, the temperature is $TEMPERATURE, the timezone is $TIMEZONE, and the elevation is $ELEVATION”. 

Include documentation with any necessary build instructions and be prepared to discuss your approach.


## Getting Started

Download the repository and build in your .Net IDE or using MSBuild.

[Getting Started with GitHub](https://help.github.com/en/articles/set-up-git).

[Walkthrough: Use MSBuild](https://docs.microsoft.com/en-us/visualstudio/msbuild/walkthrough-using-msbuild?view=vs-2019)


## Running the tests

This solution uses [NUnit](https://nunit.org/) for testing.  

For Integration tests, copy the associated `secrets-template.json` file as `secrets.json`.  
Populate the file with your API keys.  
`secrets.json` files are ignore by this repository and will not be uploaded.

In Visual Studio, load the Test Explorer and click *Run All*.


### Break down of Tests

Projects ending in `.UnitTesting` test specific logic within the matching projects not ending in `.UnitTesting`.

Projects ending in `.IntegrationTesting` test the Data Access layers calls to external 3rd Party APIs and the Presentation layer content delivery based on requirements (API to return a string not json).



## Authors

* **Erik Philips** - *Coding Example* 

## License

This project is licensed under the MIT License.


