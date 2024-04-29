using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public Button BackToMenuButton;

    private void Awake()
    {
        BackToMenuButton.onClick.AddListener(ReloadLobby);
       
    }
    private void ReloadLobby()
    {
        SceneManager.LoadScene(0);
        
    }
}
