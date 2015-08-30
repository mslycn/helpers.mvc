# helpers.mvc (MVC6, ASPNET5, vNext)
![License](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square) [![nuget package](https://img.shields.io/nuget/v/helpers.mvc.png?style=flat-square)](https://www.nuget.org/profiles/simonray)

Contains a collection of custom Tag Helpers for building ASP.NET 5, MVC 6 and Core applications.

## Setup

To install, run the following command in the Package Manager Console.

```csharp
Install-Package Helpers.mvc -pre
```

## Configuration
Add the following to the `_ViewImports.cshtml` file

```csharp
@addTagHelper "*, Helpers.mvc"
@using Helpers.TagHelpers
```

## Usage

###Pager
```html
<pager asp-for="@Model" show-status=true show-sizes=true />
```
![Alt text](http://s2.postimg.org/4u0fnrxsp/screenshot.png "pager")

## Change Log

#### 1.0.0 (25-08-15)
* Initial Release.
