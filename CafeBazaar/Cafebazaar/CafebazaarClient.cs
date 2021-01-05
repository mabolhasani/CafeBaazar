using Cafebazaar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CafeBazaar
{
    public class CafebazaarClient
    {
        private readonly CafebazaarConfiguration _configuration;
        private readonly HttpClient _client;
        private const string BaseUrl = "https://pardakht.cafebazaar.ir/devapi/v2";

        public CafebazaarClient(CafebazaarConfiguration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
        }

        public async Task<AccessTokenResult> GetAccessTokenAsync()
        {
            var body = new Dictionary<string, string>()
            {
                { "client_secret", _configuration.ClientSecret},
                {"client_id", _configuration.ClientId },
                {"refresh_token", _configuration.RefreshToken},
                {"grant_type", "refresh_token" }
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                $"{BaseUrl}/auth/token/")
            {
                Content = new FormUrlEncodedContent(body)
            };

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<AccessTokenResult>(
                    await response.Content.ReadAsStringAsync());

            throw new UnauthorizedAccessException(JsonConvert.DeserializeObject<ErrorResult>(
                    await response.Content.ReadAsStringAsync()).Error);
        }

        public async Task<VerifyInappPurchaseResult> VerifyInappPurchaseAsync(string productId, string purchaseToken)
        {
            var response = await _client.GetAsync(
               $"{BaseUrl}/api/validate/" +
               $"{_configuration.PackageName}/inapp/{productId}/purchases/" +
               $"{purchaseToken}?access_token={(await GetAccessTokenAsync()).AccessToken}");

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<InappPurchaseResult>(
                    await response.Content.ReadAsStringAsync());

                return new VerifyInappPurchaseResult(result);
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorResult>(
                     await response.Content.ReadAsStringAsync());

                return new VerifyInappPurchaseResult(result);
            }
        }

        public async Task<VerifySubscriptionPurchaseResult> VerifySubscriptionPurchaseAsync(
            string subscriptionId, string purchaseToken)
        {
            var response = await _client.GetAsync(
              $"{BaseUrl}/api/validate/" +
              $"{_configuration.PackageName}/subscriptions/{subscriptionId}/purchases/" +
              $"{purchaseToken}?access_token={(await GetAccessTokenAsync()).AccessToken}");

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<SubscriptionPurchaseResult>(
                    await response.Content.ReadAsStringAsync());

                return new VerifySubscriptionPurchaseResult(result);
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorResult>(
                     await response.Content.ReadAsStringAsync());

                return new VerifySubscriptionPurchaseResult(result);
            }
        }

        public async Task<CancelSubscriptionResult> CancelSubscriptionAsync(
            string subscriptionId, string purchaseToken)
        {
            var response = await _client.GetAsync(
                 $"{BaseUrl}/api/applications/" +
                 $"{_configuration.PackageName}/subscriptions/{subscriptionId}/purchases/" +
                 $"{purchaseToken}/cancel?access_token={(await GetAccessTokenAsync()).AccessToken}");

            if (response.IsSuccessStatusCode)
            {
                return new CancelSubscriptionResult();
            }
            else
            {
                var result = JsonConvert.DeserializeObject<ErrorResult>(
                     await response.Content.ReadAsStringAsync());

                return new CancelSubscriptionResult(result);
            }
        }
    }
}
