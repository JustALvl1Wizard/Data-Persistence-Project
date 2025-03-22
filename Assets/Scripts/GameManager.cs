using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public string playerName;
    public List<HighScoreEntry> highScores = new List<HighScoreEntry>();

    private string saveFilePath;

    private void Awake()
    {
        if (Instance != null) //singleton so only one exists at a time
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        saveFilePath = Path.Combine(Application.persistentDataPath, "highscores.json");
        LoadHighScores();
    }

    // Save the high score list to a file
    public void SaveHighScores()
    {
        HighScoreData data = new HighScoreData();
        data.highScores = highScores;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
    }

    // Load the high score list from a file
    public void LoadHighScores()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);
            highScores = data.highScores;
        }
    }

    // Add a new score entry and update the list
    public void AddHighScore(string name, int score)
    {
        HighScoreEntry entry = new HighScoreEntry();
        entry.playerName = name;
        entry.score = score;
        highScores.Add(entry);

        // Sort the list so that the highest scores come first
        highScores.Sort((a, b) => b.score.CompareTo(a.score));

        // top 10 high scores
        if (highScores.Count > 10)
            highScores.RemoveRange(10, highScores.Count - 10);

        SaveHighScores();
    }
    [System.Serializable]
    public class HighScoreEntry
    {
        public string playerName;
        public int score;
    }

    [System.Serializable]
    public class HighScoreData
    {
        public List<HighScoreEntry> highScores = new List<HighScoreEntry>();
    }
}
