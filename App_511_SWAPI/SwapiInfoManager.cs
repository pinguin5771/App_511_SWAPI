using System;
using System.Collections.Generic;
using System.Text;

namespace App_511_SWAPI;

internal class SwapiInfoManager
{
    private const string SwapiInfoUrlBase = "https://swapi.info/api/";

    private NetworkHelper networkHelper;


    public SwapiInfoManager(NetworkHelper networkHelper)
    {
        this.networkHelper = networkHelper;
    }


    public async Task<InfoBase> GetBaseInfo()
    {
        RequestResponse requestResponse = await networkHelper.SendRequest(SwapiInfoUrlBase);
        if (requestResponse.Status == RequestStatus.Ok)
        {
            InfoBase infoBase = JsonHelper.DeserializeJson<InfoBase>(requestResponse.Data);

            return infoBase;
        }

        return new();
    }

    public async Task<List<PersonData>> GetPeoplesInfo(string peoplesUrl)
    {
        RequestResponse requestResponse = await networkHelper.SendRequest(peoplesUrl);
        if (requestResponse.Status == RequestStatus.Ok)
        {
            List<PersonData> persons = JsonHelper.DeserializeJson<List<PersonData>>(requestResponse.Data);

            return persons;
        }

        return new();
    }

    public async Task<string> GetPlanetName(string planetUrl)
    {
        RequestResponse response =
            await networkHelper.GetFromCache(planetUrl);

        if (response.Status != RequestStatus.Ok)
            return "Unknown";

        var planet =
            JsonHelper.DeserializeJson<Dictionary<string, object>>(
                response.Data);

        return planet["name"]?.ToString() ?? "Unknown";
    }


    public async Task<string> GetTransportNames(PersonData person)
    {
        List<string> urls = person.Vehicles
            .Concat(person.Starships)
            .Distinct()
            .ToList();

        List<string> names = new();

        foreach (string url in urls)
        {
            RequestResponse response =
                await networkHelper.GetFromCache(url);

            if (response.Status != RequestStatus.Ok)
                continue;

            var transport =
                JsonHelper.DeserializeJson<Dictionary<string, object>>(
                    response.Data);

            if (transport.TryGetValue("name", out object? name))
                names.Add(name.ToString() ?? "");
        }

        return names.Count > 0
            ? string.Join(", ", names)
            : "No transport";
    }
}
