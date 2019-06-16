using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScreenResolution
{
    public int width;
    public int height;
}

/*
[System.Serializable]
public class OpenMenus
{
    public GameObject[] menuItems;
}
*/

public class HardCodedMainMenu : MonoBehaviour
{
    [Header("Options")]
    public List<ScreenResolution> resolutions;

    public bool isFullScreen;
    
    // public List<OpenMenus> menus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetResolution(ScreenResolution selectedRes)
    {
        Screen.SetResolution(selectedRes.width, selectedRes.height, isFullScreen);
    }
}
