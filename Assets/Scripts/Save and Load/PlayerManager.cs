using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int level;
    public new string name;
    public float healthCurrent;
    public float healthMax;

    public void SaveFunction()
    {
        Save.SaveData(this);
    }

    public void LoadData()
    {
        Data data = Save.LoadData();
        level = data.level;
        name = data.playerName;
        healthCurrent = data.healthCurrent;
        healthMax = data.healthMax;
    }

    private void Awake()
    {
        LoadData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            SaveFunction();
        }

        if (Input.GetKeyDown(KeyCode.F11))
        {
            LoadData();
        }
    }
}
