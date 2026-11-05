using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace App_511_SWAPI;

public enum RequestStatus
{
    Error,
    Ok
}

internal class RequestResponse
{
    public RequestStatus Status { get; set; }
    public string Data { get; set; } = string.Empty;

    public RequestResponse(string data, RequestStatus status = RequestStatus.Error)
    {
        Data = data;
        Status = status;
    }
}

internal class NetworkHelper
{
    private readonly HttpClient httpClient = new HttpClient();
    private readonly Dictionary<string, string> localCach = new();

    public NetworkHelper()
    {
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
    }

    public async Task<RequestResponse> GetFromCache(string url)
    {
        RequestStatus status = RequestStatus.Ok;
        string data = string.Empty;

        if (localCach.ContainsKey(url))
        {
            data = localCach[url];
        }
        else
        {
            RequestResponse requestResponse = await SendRequest(url);
            status = requestResponse.Status;

            if (requestResponse.Status == RequestStatus.Ok)
            {
                localCach[url] = requestResponse.Data;
                data = requestResponse.Data;
            }
        }

        return await Task.FromResult(new RequestResponse(data, status));
    }

    public async Task<RequestResponse> SendRequest(string url)
    {
        RequestResponse requestResponse;

        try
        {
            string result = await httpClient.GetStringAsync(url);
            requestResponse = new RequestResponse(result, RequestStatus.Ok);
        }
        catch (HttpRequestException re)
        {
            string error = re.Message;
            requestResponse = new RequestResponse(error);

            Debug.WriteLine("HttpRequestException: " + error);
        }
        catch (Exception ex)
        {
            string error = ex.Message;
            requestResponse = new RequestResponse(error);

            Debug.WriteLine("HttpRequestException: " + error);
        }

        return requestResponse;
    }

}
