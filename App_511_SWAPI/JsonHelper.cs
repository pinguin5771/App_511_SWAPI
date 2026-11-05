using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App_511_SWAPI;

internal class JsonHelper
{
    public static T DeserializeJson<T>(string jsonData)
    {
        return JsonConvert.DeserializeObject<T>(jsonData);
    }
}
