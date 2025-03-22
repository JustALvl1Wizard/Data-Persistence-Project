using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class LeaderboardDisplay : MonoBehaviour
{
    public TMP_Text leaderboardText;  

    void Start()
    {
        string displayText = "Leaderboard:\n";
        int rank = 1;
        foreach (HighScoreEntry entry in GameManager.Instance.highScores)
        {
            displayText += $"{rank}. {entry.playerName} - {entry.score}\n";
            rank++;
        }
        leaderboardText.text = displayText;
    }
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}
