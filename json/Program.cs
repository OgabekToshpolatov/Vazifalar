
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

var UserJsonList = new UserJsonList();
User user = new User("Ogabek","User");
var key = Guid.NewGuid().ToString();
Dictionary<string, User>  dictionary = new Dictionary<string, User>(); 
dictionary.Add(key,user);
var path = @"D:\vazifalar\json\json.json";
String json = JsonConvert.SerializeObject(dictionary, Newtonsoft.Json.Formatting.Indented);
 // the dictionary is inside client object
//write string to file
System.IO.File.WriteAllText(path , json);

public class UserJsonList
{
    public Dictionary<string, User> Users { get; set; }

    public UserJsonList()
    {
        Users = new Dictionary<string, User>();
    }
}

public class User
{
    public User(string name, string role)
    {
        Name = name;
        Role = role;
    }
    public string? Name { get; set; }
    public string? Role { get; set; }
}