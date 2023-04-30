using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSaving : Asaving
{
    public GameObject savingObj;

    public override void saveProperties(string keyName)
    {
        if(savingObj.activeSelf == true)
            PlayerPrefs.SetInt(keyName + "St", 1);
        else
            PlayerPrefs.SetInt(keyName + "St", 0);
    }

    public override void retreiveProperties(string keyName)
    {
        if (PlayerPrefs.HasKey(keyName + "St"))
        {
            savingObj.SetActive(false);
            if (PlayerPrefs.GetInt(keyName + "St") == 1)
            {
                savingObj.SetActive(true);
            }
        }
    }

    public override void deleteProperties(string keyName)
    {
        PlayerPrefs.DeleteKey(keyName + "St");
    }
}
