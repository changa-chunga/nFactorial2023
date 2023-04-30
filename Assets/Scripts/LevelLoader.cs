using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string[] sceneNames;
    public static LevelLoader instance;
    public UnityEvent onNoLevels;
    private void Awake()
    {
        if (!instance || instance == this)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if (PlayerPrefs.HasKey("Level") == false || PlayerPrefs.GetInt("Level") <= 0)
        {
            PlayerPrefs.SetInt("Level", 1);
        }
    }

    public void loadLevel(int level)
    {
        print(level);
        if (level - 1 < sceneNames.Length)
            SceneManager.LoadSceneAsync(sceneNames[level - 1]);
        else
            onNoLevels.Invoke();
    }

    public void returnToMenu()
    {
        StartCoroutine(returnToMenu_R());
    }

    IEnumerator returnToMenu_R()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
