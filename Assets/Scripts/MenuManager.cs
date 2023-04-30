using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public LevelButton[] levels;

    private void Awake()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (i < PlayerPrefs.GetInt("Level", 1))
            {
                levels[i].transitions.StartForwardTransition();
                for (int j = 0; j < levels[i].scores.Length; j++)
                {
                    for(int k =0; k < levels[i].scores[j].visText.Length;k++)
                    {
                        levels[i].scores[j].visText[k].text = PlayerPrefs
                            .GetInt("Score" + (i + 1).ToString() + levels[i].scores[j].element).ToString();
                    }

                }
            }
            else
                levels[i].transitions.StartReverseTransition();
        }
    }

    public void loadLevel(int lv)
    {
        if(lv <= PlayerPrefs.GetInt("Level", 1))
            LevelLoader.instance.loadLevel(lv);
    }
}
[System.Serializable]
public struct LevelButton
{
    public DoubleSideClickTransition transitions;
    public ScoreStruct[] scores;
}
