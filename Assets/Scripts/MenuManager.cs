using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField playerNameInput;

    // Called when the Start Game button is pressed
    public void StartGameButtonPressed()
    {
        // Retrieve the player's name from the input field
        string enteredName = playerNameInput.text;
        if (string.IsNullOrEmpty(enteredName))
        {
            enteredName = "Player";
        }

        // Store the name in GameManager
        GameManager.Instance.playerName = enteredName;

        // Transition to the game scene 
        SceneManager.LoadScene(1);
    }

    
    public void QuitGameButtonPressed()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    
  
}
