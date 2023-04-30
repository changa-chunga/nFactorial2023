using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Asaving: MonoBehaviour
{
    public abstract void saveProperties(string keyName);
    public abstract void retreiveProperties(string keyName);
    public abstract void deleteProperties(string keyName);
}