using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    private string username;
    private string bestUser ;
    private int score ;
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
        return Instance.username;
    }
    public string GetBestUsername()
    {
        return Instance.bestUser;
    }
    public int GetScore()
    {
        return Instance.score;
    }
    public void UpdateBestScore(string username, int score)
    {
        Instance.bestUser = username;
        Instance.score = score;
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
        if (Instance.score == 0)
            Instance.bestUser = username;
        Instance.username = username;
    }

    public void SaveStats()
    {
        SaveData data = new SaveData();
        data.username = Instance.username;
        data.score = Instance.score;
        data.bestUser = Instance.bestUser;
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
            data.username = Instance.username;
            data.bestUser = Instance.bestUser;
            data.score = Instance.score;
        }
    }

    
}
