using Newtonsoft.Json;

namespace claim.Services;

public  class JsonService
{
    public void WriteJson(string key, User user)
    {
        Dictionary<string, User>  dictionary = new Dictionary<string, User>(); 
        dictionary.Add(key,user);
        var path = @"D:\vazifalar\claim\json.json";
        String json = JsonConvert.SerializeObject(dictionary, Newtonsoft.Json.Formatting.Indented);
        System.IO.File.WriteAllText(path , json);
    }
}