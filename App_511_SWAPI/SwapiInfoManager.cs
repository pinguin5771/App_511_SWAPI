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
}
