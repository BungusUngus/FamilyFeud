using UnityEngine;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    
    public List<Question> questions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Save Game")]
    public void SaveGame()
    {
        SavedData savedData = new SavedData();
        foreach(Question q in questions)
            savedData.questions.Add(q);
        JSON_Manager.SaveToJson( savedData );
    }

    [ContextMenu("Load Game")]
    public void LoadGame()
    {
        SavedData newData = JSON_Manager.LoadFromJson();
        questions.Clear();
        foreach (Question q in newData.questions)
            questions.Add(q);
    }
}

[System.Serializable]
public class Question
{
    public string question;
    public List<string> responses = new List<string>();
}
