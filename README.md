# Cafebazaar Rest API Documentation 
![.NET](https://github.com/mabolhasani/Cafebazaar/workflows/.NET/badge.svg)
[![NuGet version (CafebazaarApi)](https://img.shields.io/nuget/v/CafebazaarApi.svg)](https://www.nuget.org/packages/CafebazaarApi/)\
This is a simple C# implantation of Cafebazaar Rest API,
for more information you can go to cafebazaar documentation [page](https://developers.cafebazaar.ir/en/docs/developer-api-v2-introduction/developer-api-v2-getting-started/) 

# Installation 
##### Package Manager
```
Install-Package CafebazaarApi -Version 1.0.0
```
##### .NET CLI
```
dotnet add package CafebazaarApi --version 1.0.0
```

# Usage 
First of all you must create configuration instance and initialize it with proper config
```csharp
var config = new CafebazaarConfiguration(
                "Your client id", "Your client secret"
                "Your package name", "Your refresh token");
```
Then pass it to CafebazaarClient 
```csharp
var client = new CafebazaarClient(config);
```
For verify Inapp purchase you can call this method
```csharp
var result = await client.VerifyInappPurchaseAsync("ProductId", "Purchase token");
```
And for verify Subscription purchase you can call this
```csharp
var result = await client.VerifySubscriptionPurchaseAsync("Subscription id", "Purchase token");
```
And finally for canceling subscription you can call this
```csharp
var result = await client.CancelSubscriptionAsync("Subscription id", "Purchase token");
```
**Access token will be generated and passed it internally in all methods based on your refresh token** 

Then you can check the result of your request and and do what ever you want :)
```csharp
 if (result.Successful)
 {
	 //use result.PurchaseResult
	 //...
 }
 else
 {
	 //use result.Error
	 //...
 }
```
---
***Feel free to contact me or fork this repository for improvement :)***
