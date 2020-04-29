using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace DemoPortal.Utility
{
    public class Api
    {
        public static TResponse ApiRequest<TRequest, TResponse>(TRequest request, string ApiName, string MType, bool enableSSL = false) where TResponse : class
        {

            try
            {
                TResponse response = default(TResponse);
                using (var handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler, true))
                    {
                        if (MType == "Post")
                        {
                            client.BaseAddress = new Uri(Settings.ApiUrl);
                            HttpResponseMessage httpResponseMessage = client.PostAsJsonAsync<TRequest>(ApiName, request).Result;
                            var rpsMessage = httpResponseMessage.Content.ReadAsAsync<TResponse>();
                            response = rpsMessage.Result;

                        }
                        else if (MType == "Put")
                        {
                            client.BaseAddress = new Uri(Settings.ApiUrl);
                            HttpResponseMessage httpResponseMessage = client.PutAsJsonAsync<TRequest>(ApiName, request).Result;
                            var rpsMessage = httpResponseMessage.Content.ReadAsAsync<TResponse>();
                            response = rpsMessage.Result;

                        }
                        else
                        {
                            client.BaseAddress = new Uri(Settings.ApiUrl);
                            var responseTask = client.GetAsync(ApiName); // responseTask.Wait();
                            var result = responseTask.Result;
                            if (result.IsSuccessStatusCode)
                            {
                                var readTask = result.Content.ReadAsAsync<TResponse>();// readTask.Wait();
                                var res = readTask.Result; response = res;
                            }
                            else //web api sent error response 
                            {
                                response = "Fail" as TResponse;
                            }
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}