using System;
using System.Collections.Generic;
using System.Text;

namespace App_511_SWAPI;

internal static class DataMerger
{
    public static List<PersonData> MergeData(List<PersonData> persons, List<ImageItem> images)
    {
        foreach(var person in persons)
        {
            person.ImageUrl = images.FirstOrDefault(i => string.Equals(i.Name, person.Name))?.Image ?? string.Empty;
        }

        return persons;
    }
}
