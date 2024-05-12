using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static LevelManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public LevelsStatus GetLevelStatus(string level)
    {
        LevelsStatus levelStatus = (LevelsStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }
    public void SetLevelStatus(string level, LevelsStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}
