using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

public class SaveLoad : MonoBehaviour
{
    DataForSaveLoad data;

    private readonly string folderPath = Application.dataPath.ToString() + "/Save";
    private readonly string filePath = Application.dataPath.ToString() + "/Save/Save.json";

    public void Save()
    {
        if (Directory.Exists(folderPath) == false)
        {
            Directory.CreateDirectory(folderPath);
        }

        data = data.GetSaveData();

        string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(filePath, jsonString);        
    }

    public void Load()
    {
        string jsonString = File.ReadAllText(filePath);

        data.GetLoadData(jsonString);
    }
}
