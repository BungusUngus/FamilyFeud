using UnityEngine;
using System.IO;
using System.Collections.Generic;

public static class JSON_Manager
{
    const string SaveDirectory = "/SavedData/";
    const string FileName = "requested template";

    public static void SaveToJson(SavedData data)
    {
        string dir = Application.persistentDataPath + SaveDirectory;
        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(data,true);
        Debug.Log(json);
        File.WriteAllText(dir + FileName, json);

        GUIUtility.systemCopyBuffer = dir;
    } 

    public static SavedData LoadFromJson()
    {
        string dir = Application.persistentDataPath + SaveDirectory + FileName;
        if (File.Exists(dir))
        {
            string json = File.ReadAllText(dir);
            return JsonUtility.FromJson<SavedData>(json);
        } else
        {
            Debug.Log("Load failed. No file found!"); //Did you save the file first?
            return null;
        }
    }
    
}

public class SavedData
{
    //public string name = "Indigo";
    //public int age = 152;
    //public Vector3 position = new Vector3(0,50,-72);
    //public bool haveGun = false;
    //public List<string> children = new List<string> { "Gold", "Silver", "Bronze"};
    public List<Question> questions = new List<Question>();
}
