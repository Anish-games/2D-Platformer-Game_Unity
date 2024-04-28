using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button RestartButton;
    private void Awake()
    {
        RestartButton.onClick.AddListener(ReloadLevel);
    }
    public void PlayerDie()
    {
        gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);

    }
}
