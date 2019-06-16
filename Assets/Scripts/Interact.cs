using UnityEngine;
using System.Collections;
[AddComponentMenu("Intro PRG/RPG/Player/Interact")] //this script can be found in the Component section under the option Intro RPG/Player/Interact
public class Interact : MonoBehaviour 
{
    #region Variables
    //We are setting up these variable and the tags in update for week 3,4 and 5
    //[Header("Player and Camera connection")]
    //create two gameobject variables one called player and the other mainCam

    public GameObject player;

    #endregion
    #region Start
    //connect our player to the player variable via tag
    //connect our Camera to the mainCam variable via tag
    #endregion
    #region Update

    private void Update()
    {
        if (Input.GetButtonDown("Interact")) //if our interact key is pressed
        {
            Ray interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); //create a ray shooting out from the main cameras screen point center of screen
            RaycastHit interactInfo; //create hit info

            if (Physics.Raycast(interact, out interactInfo, 10)) //if this physics raycast hits something within 10 units
            {
                #region NPC tag
                if (interactInfo.collider.CompareTag("NPC")) //and that hits info is tagged NPC
                {
                    Debug.Log("NPC"); //Debug that we hit a NPC

                    /*
                    QuestGiver q = interactInfo.transform.GetComponent<QuestGiver>();
                    if (q != null)
                    {

                    }
                    */

                    Dialogue d = interactInfo.transform.GetComponent<Dialogue>();
                    if (d != null)
                    {
                        d.showDialogue = true;
                        d.player = player;
                        //player.GetComponent<Movement>().canMove = false;
                        Movement.canMove = true; // This was changed to a static variable, use the above line if non-static
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                    }
                }
                #endregion
                #region Item
                else if (interactInfo.collider.CompareTag("Item")) //and that hits info is tagged Item
                {
                    Debug.Log("Item"); //Debug that we hit an Item
                    ItemHandler handler = interactInfo.transform.GetComponent<ItemHandler>();
                    if (handler != null)
                    {
                        handler.OnCollection();
                    }
                }
                #endregion
                #region None
                else //and that hits info is tagged Item
                {
                    Debug.Log("Nothing of note identified"); //Debug that we hit an Item
                }
                #endregion
            }
        }
    }
    
    #endregion
}