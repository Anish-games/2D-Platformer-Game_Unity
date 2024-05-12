using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    private void onClick()
    {
        LevelsStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelsStatus.Locked:
                Debug.Log("can't play this level till you unlock it");
                break;
            case LevelsStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;
            case LevelsStatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}
