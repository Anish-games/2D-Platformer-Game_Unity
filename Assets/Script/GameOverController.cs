using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    
    public Button RestartButton;
    public Button QuitButton;
    private void Awake()
    {
        RestartButton.onClick.AddListener(ReloadLevel);
        QuitButton.onClick.AddListener(QuitGame);
    }
    public void PlayerDie()
    {
        gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);

    }
    void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
