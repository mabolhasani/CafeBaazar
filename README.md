# Cafebazaar Rest Api Documentation 
This is a simple C# implantation of Cafebazaar rest api
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

#Usage 
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
For verify Inapp purchase you can call this methods [docs](https://developers.cafebazaar.ir/en/docs/developer-api-v2-introduction/developer-api-v2-ref-validate/)
```csharp
var result = client.VerifyInappPurchaseAsync("ProductId", "Purchase token");
```
For verify Subscription purchase you can call this methods [docs](https://developers.cafebazaar.ir/en/docs/developer-api-v2-introduction/developer-api-v2-ref-get-subs/)
```csharp
var result = client.VerifySubscriptionPurchaseAsync("Subscription id", "Purchase token");
```
For verify canceling subscription you can call this methods [docs](https://developers.cafebazaar.ir/en/docs/developer-api-v2-introduction/developer-api-v2-ref-cancel-subs/)
```csharp
var result = client.CancelSubscriptionAsync("Subscription id", "Purchase token");
```
**For verify purchase or canceling one, you do not need to get access token and pass it to methods,  it'll generate access token for you on every request** 

### Usage of the result
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