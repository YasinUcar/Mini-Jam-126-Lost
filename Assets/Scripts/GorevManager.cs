using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorevManager : MonoBehaviour
{
    
    
    public string StringLevelName
    {
        get
        {
            return PlayerPrefs.GetString("LevelName" + name);
        }
        set
        {
            PlayerPrefs.SetString("LevelName" + name, value);
        }
    }
}
