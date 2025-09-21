using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This function is for Play Button
    public void PlayGame()
    {
        // Replace "GameScene" with the exact name of your game scene
        SceneManager.LoadScene("GameScene");
    }

    // This function is for About Button
    public void GoToAbout()
    {
        // Replace "AboutScene" with the name of your about scene
        SceneManager.LoadScene("AboutScene");
    }

    // This function is for Quit Button
    public void QuitGame()
    {
        Debug.Log("Quit Game!"); // This will show in editor
        Application.Quit(); // This will quit the game after building
    }
}
