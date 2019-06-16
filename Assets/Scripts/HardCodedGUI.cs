using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardCodedGUI : MonoBehaviour {

    public enum GuiObject
    {
        Text,
        Image,
        RawImage,
        Button,
        Toggle,
        Slider,
        Scrollbar,
        Dropdown,
        InputField,
        Panel,
        ScrollView
    }

    public struct GuiElements
    {
        public GuiObject type;
        public float xPos;
        public float yPos;
        public float xSize;
        public float ySize;
    }

    float sw;
    float sh;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if (sw != Screen.width / 16)
        {
            sw = Screen.width / 16;
            sh = Screen.height / 9;
        }

        if (GUI.Button(new Rect(0, 0, sw * 3, sh * 1.5f), "Button"))
        {

        }
    }
}
