using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : BaseController
{
    public int LevelIndex
    {
        get
        {
            return PlayerPrefs.GetInt("LevelIndex", 0);
        }
        set
        {
            PlayerPrefs.SetInt("LevelIndex", value);
        }
    }
}