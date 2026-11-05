using System;
using System.Collections.Generic;
using System.Text;

namespace App_511_SWAPI;

internal class ImageDataManager
{
    private const string ImageDataUrlBase = "https://akabab.github.io/starwars-api/api/all.json";

    private NetworkHelper networkHelper;


    public ImageDataManager(NetworkHelper networkHelper)
    {
        this.networkHelper = networkHelper;
    }


    public async Task<List<ImageItem>> GetImagesDataInfo()
    {
        RequestResponse requestResponse = await networkHelper.SendRequest(ImageDataUrlBase);
        if (requestResponse.Status == RequestStatus.Ok)
        {
            List<ImageItem> items = JsonHelper.DeserializeJson<List<ImageItem>>(requestResponse.Data);

            return items;
        }

        return new();
    }
   
}
