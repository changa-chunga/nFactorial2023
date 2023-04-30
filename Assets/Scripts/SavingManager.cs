using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingManager : MonoBehaviour
{
    public saving[] savingControllers;
    public static SavingManager instance;

    public SavingManager()
    {
        instance = this;
    }

    public void Load()
    {
        if (PlayerPrefs.GetInt("HasSave" + LevelManager.instance.level.ToString(), 0) != 1)
            return;
        for (int i = 0; i < savingControllers.Length; i++)
        {
            savingControllers[i].controller.retreiveProperties(LevelManager.instance.level.ToString() + savingControllers[i].keyName);
            savingControllers[i].controller.deleteProperties(LevelManager.instance.level.ToString() + savingControllers[i].keyName);
        }
        for (int i = 0; i < LevelManager.instance.scores.Length; i++)
        {
            LevelManager.instance.score(LevelManager.instance.scores[i].element,
                PlayerPrefs.GetInt(
                    LevelManager.instance.level.ToString() + "Score" + LevelManager.instance.scores[i].element, 0));
            PlayerPrefs.DeleteKey(LevelManager.instance.level.ToString() + "Score" + LevelManager.instance.scores[i].element);
        }

        LevelManager.instance.timeSpent = PlayerPrefs.GetInt(LevelManager.instance.level.ToString() + "Time", 0);
        PlayerPrefs.DeleteKey("HasSave" + LevelManager.instance.level.ToString());
    }

    public void performSave()
    {
        for (int i = 0; i < savingControllers.Length; i++)
        {
            savingControllers[i].controller.saveProperties(LevelManager.instance.level.ToString() + savingControllers[i].keyName);
            
        }
        for (int i = 0; i < LevelManager.instance.scores.Length; i++)
        {
            PlayerPrefs.SetInt(
                LevelManager.instance.level.ToString() + "Score" + LevelManager.instance.scores[i].element,
                LevelManager.instance.scores[i].score);
        }

        PlayerPrefs.SetInt(LevelManager.instance.level.ToString() + "Time",
            Mathf.FloorToInt(LevelManager.instance.timeSpent));
        PlayerPrefs.SetInt("HasSave" + LevelManager.instance.level.ToString(), 1);
    }
}

[System.Serializable]
public struct saving
{
    public string keyName;
    public Asaving controller;
}
