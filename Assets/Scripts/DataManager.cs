using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager dataInstance;
    public int highscore;
    public string currentPlayer;
    public string highscorer;

    public void Awake()
    {
        if (dataInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            dataInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int highscore;
        public string highscorer;
    }

    public void SaveHighscore()
    {
        Debug.Log("Saving");
        SaveData data = new SaveData();
        data.highscore = highscore;
        data.highscorer = highscorer;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        Debug.Log("Loading");
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highscore = data.highscore;
            highscorer = data.highscorer;

        } 
    }

}
