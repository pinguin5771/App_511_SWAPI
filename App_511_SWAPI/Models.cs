using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_511_SWAPI;

//"films": "https://swapi.info/api/films",
//	"people": "https://swapi.info/api/people",
//	"planets": "https://swapi.info/api/planets",
//	"species": "https://swapi.info/api/species",
//	"vehicles": "https://swapi.info/api/vehicles",
//	"starships": "https://swapi.info/api/starships"

public class InfoBase
{
    [JsonProperty("films")]
    public string FilmsUrl { get; set; } = string.Empty;

    [JsonProperty("people")]
    public string PeoplesUrl { get; set; } = string.Empty; 

    [JsonProperty("planets")]
    public string PlanetsUrl { get; set; } = string.Empty;

    [JsonProperty("species")]
    public string SpeciesUrl { get; set; } = string.Empty;

    [JsonProperty("vehicles")]
    public string VehiclesUrl { get; set; } = string.Empty;

    [JsonProperty("starships")]
    public string StarshipsUrl { get; set; } = string.Empty;
}

public class PersonData
{
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("height")]
    public string Height { get; set; } = string.Empty;

    [JsonProperty("mass")]
    public string Mass { get; set; } = string.Empty;

    [JsonProperty("hair_color")]
    public string HairColor { get; set; } = string.Empty;

    [JsonProperty("skin_color")]
    public string SkinColor { get; set; } = string.Empty;

    [JsonProperty("eye_color")]
    public string EyeColor { get; set; } = string.Empty;

    [JsonProperty("birth_year")]
    public string BirthYear { get; set; } = string.Empty;

    [JsonProperty("homeworld")]
    public string Homeworld { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public override string ToString() => Name;
}

public class ImageItem
{
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("image")]
    public string Image { get; set; } = string.Empty;
}
