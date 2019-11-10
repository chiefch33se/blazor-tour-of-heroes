# Blazor Tour of Heroes

[![Build Status](https://travis-ci.org/georgemathieson/blazor-tour-of-heroes.svg?branch=master)](https://travis-ci.org/georgemathieson/blazor-tour-of-heroes)

The [Angular Tour of Heroes](https://angular.io/tutorial) tutorial, but done using [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) instead. Largely built as an opportunity to learn server-side Blazor with a Redux style state management system.

![Heroes screenshot](/screenshots/heroes.png)

## Running the App

### Local Machine
You'll want the latest version of the [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core).

The simplest way is to use VSCode or Visual Studio to run the project.

You can run using the command line: `dotnet run --project src/TourOfHeroes.Web"`.

The tests can also be run this way: `dotnet test`.

### Publishing to Azure
Deploy by running `docker-compose up`.

⚠️ For server-side Blazor, you'll need to use a SignalR Service in conjunction with an App Service for things to work.

You can then push the Docker image into Azure (or wherever) and consume it using an App Service. You will need to add the application setting `Azure__SignalR__ConnectionString` in your App Service's Configuration and set its value to the SignalR Service connection string. 

## Libraries

* [Adorable Avatars!](avatars.adorable.io) for the.. adorable avatars
* [Blazor-State](https://github.com/TimeWarpEngineering/blazor-state) for the Redux style state
* [Blazored Typeahead](https://github.com/Blazored/Typeahead) for Typeahead control on the search

## Demo
The [demo site](https://blazor-tour-of-heroes.azurewebsites.net/) is hosted on a free Azure site, so be gentle 😄.
