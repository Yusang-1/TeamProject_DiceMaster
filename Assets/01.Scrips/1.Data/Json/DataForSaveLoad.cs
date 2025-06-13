using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class DataForSaveLoad : MonoBehaviour
{
    

    public DataForSaveLoad GetSaveData()
    {

        return new DataForSaveLoad();
    }

    public void GetLoadData(string jsonString)
    {
        JObject root = JObject.Parse(jsonString);

        JToken player = root["player"];
        JToken inven = root["inventory"]; //아마 이런식?
    }
}
