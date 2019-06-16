using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Data
{
    public int level;
    public string playerName;
    public float healthCurrent;
    public float healthMax;

    public Data(PlayerManager player)
    {
        level = player.level;
        playerName = player.name;
        healthCurrent = player.healthCurrent;
        healthMax = player.healthMax;
    }

 
}
