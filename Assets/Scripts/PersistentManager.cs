using UnityEngine;
using System.IO;

public class PersistentManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static PersistentManager Instance;

    public int highScore = 0;
    public string scoreholderName = "N/A";
    public string currentName = "N/A";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Save()
    {
        SaveData data = new SaveData();
        //data.teamColor = TeamColor;
        data.highScore = highScore;
        data.scoreholderName = scoreholderName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Saved: " + scoreholderName + highScore);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //TeamColor = data.teamColor;
            highScore = data.highScore;
            scoreholderName = data.scoreholderName;
            Debug.Log("Loaded: " + scoreholderName + highScore);
        }
    }

    public string GetHighScoreString()
    {
        return "HIGH SCORE: " + scoreholderName + ": " + highScore;
    }
}

class SaveData
{
        public int highScore;
        public string scoreholderName;
}
