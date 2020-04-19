# webapitemplate

Template of .NET Core Web API that can be used to create new applications.  

## Documentation

Visual Studio 2019 .NET Core 3.1 project includes the following components:
* Business Logic Model            -   main model reflecting business purpose of the application
* Business Logic Action           -   actions performed on business entities
* Business Logic Action Runner    -   action runner handles actions coordinations
* Data                            -   dummy data layer
* Service                         -   service exposing business actions and data to high level components
* DtoWrapper                      -   wraps data according to HATEOAS methodology 
* WebApi                          -   presentation layer

### Third-Party components

* Newtonsoft.Json
* Automapper

## Usage

Just fork the solution and modify according to your needs.

## Future plans

Add Api authentication/authorization (AD, OpenID).

## License
DupDetectorML is a public domain work, dedicated using [CC0 1.0](https://creativecommons.org/publicdomain/zero/1.0/). Feel free to do whatever you want with it.