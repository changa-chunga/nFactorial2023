using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public int level;
    public static LevelManager instance;
    public toReach[] requirements;
    public UnityEvent OnWin, OnLose;
    public bool paused;
    public UnityEvent onPause, onUnpause;
    public ScoreStruct[] scores;
    public float timeSpent;
    public TextMeshProUGUI[] timeVis;
    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
        
        for (int i = 0; i < scores.Length; i++)
        {
            for(int t = 0; t < scores[i].visText.Length;t++)
                scores[i].visText[t].text = scores[i].score.ToString();
        }
        
        SavingManager.instance.Load();
        StartCoroutine(measureTime());
        StartCoroutine(check());
    }

    IEnumerator measureTime()
    {
        timeSpent += Time.deltaTime * Time.timeScale;
        yield return null;
        StartCoroutine(measureTime());
    }

    string normalizeNumber(int num)
    {
        if (num <= 9)
        {
            return "0" + num.ToString();
        }
        else
        {
            return num.ToString();
        }
    }
    IEnumerator check()
    {
        for (int i = 0; i < timeVis.Length; i++)
        {
            timeVis[i].text = normalizeNumber(Mathf.FloorToInt(timeSpent / 60)) + ":" + normalizeNumber(Mathf.FloorToInt(timeSpent )% 60);
        }
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(check());
    }
    public void score(elementTag elTag, int scoreToAdd)
    {
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i].element == elTag)
            {
                scores[i].score += scoreToAdd;
                for(int t = 0; t < scores[i].visText.Length;t++)
                    scores[i].visText[t].text = scores[i].score.ToString();
            }
        }
    }

    public void GameOver()
    {
        OnLose.Invoke();
        PlayerPrefs.SetInt("Time" + level, 0);
        StopAllCoroutines();
    }

    public void Win()
    {
        OnWin.Invoke();
        PlayerPrefs.SetInt("Level", Mathf.Max(level + 1, PlayerPrefs.GetInt("Level")));
        PlayerPrefs.SetInt("Time" + level, 0);
        for (int i = 0; i < scores.Length; i++)
        {
            PlayerPrefs.SetInt("Score" + level + scores[i].element, Mathf.Max(scores[i].score, PlayerPrefs.GetInt("Score" + level + scores[i].element)));
        }
        StopAllCoroutines();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (paused)
            {
                unPause();
            }
            else
            {
                pause();
            }
        }
    }

    public void setPlayerReached(elementTag player, bool state)
    {
        for (int i = 0; i < requirements.Length; i++)
        {
            if (requirements[i].playerTag == player)
            {
                requirements[i].reached = state;
                break;
            }
        }
        checkWinCon();
    }

    public void checkWinCon()
    {
        for (int i = 0; i < requirements.Length; i++)
        {
            if (requirements[i].reached == false)
            {
                return;
            }
        }
        Win();
    }

    public void TogglePause()
    {
        if (paused)
        {
            unPause();
        }
        else
        {
            pause();
        }
    }
    public void pause()
    {
        Time.timeScale = 0.00001f;
        paused = true;
        onPause.Invoke();
    }

    public void unPause()
    {
        Time.timeScale = 1;
        paused = false;
        onUnpause.Invoke();
    }

    public void Restart()
    {
        LevelLoader.instance.loadLevel(level);
    }

    public void next()
    {
        LevelLoader.instance.loadLevel(level + 1);
    }

    public void toMenu()
    {
        LevelLoader.instance.returnToMenu();
    }

    public void saveAndQuit()
    {
        unPause();
        SavingManager.instance.performSave();
        toMenu();
    }
}

[System.Serializable]
public struct toReach
{
    public elementTag playerTag;
    public bool reached;
}
[System.Serializable]
public struct ScoreStruct
{
    public elementTag element;
    public int score;
    public TextMeshProUGUI[] visText;
}
