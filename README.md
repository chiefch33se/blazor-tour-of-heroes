# Blazor Tour of Heroes

[![Build Status](https://travis-ci.org/georgemathieson/blazor-tour-of-heroes.svg?branch=master)](https://travis-ci.org/georgemathieson/blazor-tour-of-heroes)

The [Angular Tour of Heroes](https://angular.io/tutorial) tutorial, but done using [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) instead. Largely built as an opportunity to learn server-side Blazor with a Redux style state management system.

![Heroes screenshot](/screenshots/heroes.png)

## Running the App

### Docker
Deploy by running `docker-compose up`.

### Local Machine
You'll want the latest version of the [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core).

To run the app from the command line: `dotnet run --project src/TourOfHeroes.Web`.

The tests can also be ran from the command line: `dotnet test`.

## Libraries

* [Blazor-State](https://github.com/TimeWarpEngineering/blazor-state) for the Redux style state
* [Blazored Typeahead](https://github.com/Blazored/Typeahead) for Typeahead control on the search
