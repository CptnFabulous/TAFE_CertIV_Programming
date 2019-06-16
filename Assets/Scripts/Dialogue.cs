using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public bool showDialogue;
    public string[] dialogueText;
    public Vector2 screen;
    public Vector2 aspectRatio = new Vector2(16, 9);

    public int dialogueIndex;
    public int dialogueOptions;


    public GameObject player;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (showDialogue)
        {
            if (screen.x != Screen.width / aspectRatio.x || screen.y != Screen.height / aspectRatio.y)
            {
                screen.x = Screen.width / aspectRatio.x;
                screen.y = Screen.height / aspectRatio.y;
            }

            GUI.Box(new Rect(0, 6 * screen.x, Screen.width, 3 * screen.y), dialogueText[dialogueIndex]);


            //if (!(dialogueIndex + 1) >= dialogueText.Length - 1)
            //if (dialogueIndex < dialogueText.Length)
            if (dialogueIndex < dialogueText.Length || dialogueIndex == dialogueOptions)
            {
                if (GUI.Button(new Rect(15 * screen.x, 8.5f * screen.y, screen.x, 0.5f * screen.y), "Next"))
                {
                    dialogueIndex++;
                }
            }
            else if (dialogueIndex == dialogueOptions)
            {
                if (GUI.Button(new Rect(13 * screen.x, 8.5f * screen.y, screen.x, 0.5f * screen.y), "Accept"))
                {
                    dialogueIndex++;
                }
                if (GUI.Button(new Rect(14 * screen.x, 8.5f * screen.y, screen.x, 0.5f * screen.y), "Decline"))
                {
                    dialogueIndex = dialogueText.Length - 1;
                }
            }

            else
            {
                if (GUI.Button(new Rect(15 * screen.x, 8.5f * screen.y, screen.x, 0.5f * screen.y), "Bye"))
                {
                    dialogueIndex = 0;
                    showDialogue = false;
                    //player.GetComponent<Movement>().canMove = true;
                    Movement.canMove = true; // This was changed to a static variable, use the above line if non-static
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
            }
        }

    }
}
