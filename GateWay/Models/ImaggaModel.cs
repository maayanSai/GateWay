using Newtonsoft.Json;
using RestSharp;

public class ImaggaModel
{
    public List<string> CheckImage(string imageUrl)
    {
        List<string> Result = null;

        string apiKey = "acc_3d60a751e375dec";
        string apiSecret = "ab6de5aa8915be606ddc95f89971361c";

        string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

        var client = new RestClient("https://api.imagga.com/v2/tags");
        var request = new RestRequest();
        request.AddParameter("image_url", imageUrl);
        request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

        RestResponse response = client.Execute(request);

        // Check the actual JSON response
        Console.WriteLine(response.Content);

        Result = ConvertToTags(response.Content);
        return Result;
    }

    public List<string> ConvertToTags(string response)
    {
        List<string> Result = new List<string>();
        Root2 theTags = JsonConvert.DeserializeObject<Root2>(response);

        // Check if the structure of theTags matches the JSON response
        if (theTags != null && theTags.result != null && theTags.result.tags != null)
        {
            foreach (Tag item in theTags.result.tags)
            {
                Result.Add(item.tag.en);
            }
        }

        return Result;
    }
}

public class Tag2
{
    public string en { get; set; }
}

public class Tag
{
    public double confidence { get; set; }
    public Tag2 tag { get; set; }
}

public class Result
{
    public List<Tag> tags { get; set; }
}

public class Status
{
    public string text { get; set; }
    public string type { get; set; }
}

public class Root2
{
    public Result result { get; set; }
    public Status status { get; set; }
}
