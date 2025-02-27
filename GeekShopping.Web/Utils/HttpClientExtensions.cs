﻿using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.Web.Utils;

public static class HttpClientExtensions
{
    private static MediaTypeHeaderValue contentyType = new MediaTypeHeaderValue("application/json");
    public static async Task<T?> ReadContentAsync<T>(this HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            throw new ApplicationException($"Something went wront calling the API: {response.ReasonPhrase}");

        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
    {
        var dataAsString = JsonSerializer.Serialize(data);

        var content = new StringContent(dataAsString);

        content.Headers.ContentType = contentyType;

        return httpClient.PostAsync(url, content);
    }

    public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
    {
        var dataAsString = JsonSerializer.Serialize(data);

        var content = new StringContent(dataAsString);

        content.Headers.ContentType = contentyType;

        return httpClient.PutAsync(url, content);
    }
}