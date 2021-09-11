using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    private string username;
    private string bestUser = "";
    private int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public string GetUsername()
    {
        return username;
    }
    public string GetBestUsername()
    {
        return bestUser;
    }
    public int GetScore()
    {
        return score;
    }
    public void UpdateBestScore(string username, int score)
    {
        this.username = username;
        this.score = score;
    }

    [System.Serializable]
    class SaveData
    {
        public string username;
        public string bestUser;
        public int score;
    }

    public void SetUsername(string username)
    {
        this.username = username;
        if(score == 0)
        {
            bestUser = username;
        }
    }

    public void SaveStats()
    {
        SaveData data = new SaveData();
        data.username = this.username;
        data.score = this.score;
        data.bestUser = this.bestUser;
        string path = Application.persistentDataPath + "/savefile.json";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public void LoadStats()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            data.username = username;
            data.bestUser = bestUser;
            data.score = score;
        }
    }

    
}
