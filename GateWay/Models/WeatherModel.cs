using Newtonsoft.Json;
using RestSharp;

public class WeatherModel
{
    public double Checkweather(string city)
    {
        //  string Result = string.Empty;

        string apiKey = "5158de7d3dfa797d71b9f0179f23547a";

        //string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}", apiKey)));

        var client = new RestClient("https://api.openweathermap.org/data/2.5/weather");
        var request = new RestRequest();
        request.AddParameter("q", city);
        request.AddParameter("appid", apiKey);
        //request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

        RestResponse response = client.Execute(request);
        // Root theTags = JsonConvert.DeserializeObject<Root>(response);

        Root Result = JsonConvert.DeserializeObject<Root>(response.Content);
        // גוגל אמר להוריד 273.15
        return (Result.main.temp)-273.15;
    }

}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Clouds
{
    public int all { get; set; }
}

public class Coord
{
    public double lon { get; set; }
    public double lat { get; set; }
}

public class Main
{
    public double temp { get; set; }
    public double feels_like { get; set; }
    public double temp_min { get; set; }
    public double temp_max { get; set; }
    public int pressure { get; set; }
    public int humidity { get; set; }
}

public class Rain
{
    [JsonProperty("1h")]
    public double _1h { get; set; }
}

public class Root
{
    public Coord coord { get; set; }
    public List<WeatherModel> weather { get; set; }
    public string @base { get; set; }
    public Main main { get; set; }
    public int visibility { get; set; }
    public Wind wind { get; set; }
    public Rain rain { get; set; }
    public Clouds clouds { get; set; }
    public int dt { get; set; }
    public Sys sys { get; set; }
    public int timezone { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public int cod { get; set; }
}

public class Sys
{
    public int type { get; set; }
    public int id { get; set; }
    public string country { get; set; }
    public int sunrise { get; set; }
    public int sunset { get; set; }
}

public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
}

public class Wind
{
    public double speed { get; set; }
    public int deg { get; set; }
}
