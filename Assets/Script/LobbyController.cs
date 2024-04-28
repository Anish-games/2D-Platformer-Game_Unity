using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LobbyController : MonoBehaviour
{
    public Button StartButton;
    public Button QuitButton;
    private void Awake()
    {
        StartButton.onClick.AddListener(ReloadLevel);
        QuitButton.onClick.AddListener(QuitGame);
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);

    }
    public void QuitGame()
    { 
      Application.Quit();
        Debug.Log("Game is exiting");
    }
}
