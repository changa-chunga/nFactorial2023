using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RBSavingController : Asaving
{
    public Rigidbody2D savingRB;

    public override void saveProperties(string keyName)
    {
        string pos = decimal.Round((decimal)savingRB.position.x, 2, MidpointRounding.AwayFromZero).ToString()
            + ";" + decimal.Round((decimal)savingRB.position.y, 2, MidpointRounding.AwayFromZero).ToString();
        PlayerPrefs.SetString(keyName + "Pos", pos);
        PlayerPrefs.SetInt(keyName + "Rot", Mathf.RoundToInt(savingRB.rotation));
    }

    public override void retreiveProperties(string keyName)
    {
        if (PlayerPrefs.HasKey(keyName + "Pos") && PlayerPrefs.HasKey(keyName + "Rot"))
        {
            string[] pos = PlayerPrefs.GetString(keyName + "Pos").Split(";");
            savingRB.position = new Vector2(float.Parse(pos[0]), float.Parse(pos[1]));
            savingRB.rotation = PlayerPrefs.GetInt(keyName + "Rot");
        }
    }

    public override void deleteProperties(string keyName)
    {
        PlayerPrefs.DeleteKey(keyName + "Pos");
        PlayerPrefs.DeleteKey(keyName + "Rot");
    }
}
