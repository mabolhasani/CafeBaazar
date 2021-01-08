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
Create configuration instance and initialize it with proper config:
```csharp
var config = new CafebazaarConfiguration(
                "client_id", "client_secret"
                "package_name", "refresh_token");
```
Then pass it to CafebazaarClient:
```csharp
var client = new CafebazaarClient(config);
```
For verify in-app purchases you can call this method:
```csharp
var result = await client.VerifyInappPurchaseAsync("product_id", "purchase_token");
```
And for verify subscription purchase you can call:
```csharp
var result = await client.VerifySubscriptionPurchaseAsync("subscription_id", "purchase_token");
```
And finally for canceling subscription you can call:
```csharp
var result = await client.CancelSubscriptionAsync("subscription_id", "purchase_token");
```
**Access token will be generated and passed internally to methods above using your refresh token** 

Then you can check the result of your request and it's all set up!
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
