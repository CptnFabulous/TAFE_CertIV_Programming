using UnityEngine;
using System.Collections;


[AddComponentMenu("Intro RPG/Player/Checkpoint")]
//this script can be found in the Component section under the option Intro RPG/Player/Check Point
public class CheckPoint : MonoBehaviour 
{
    #region Variables
    [Header("Check Point Elements")]
    public Transform currentCheckpoint; //transform for our currentCheck
    [Header("Character Health")]
    public PlayerManager playerStats; //character Health script that holds the players health
    #endregion

    #region Start
    private void Start()
    {
        playerStats = GetComponent<PlayerManager>(); //Reference to the character health script component attached to our player

        #region Check if we have Key
        /*
        if () //if we have a save key called SpawnPoint
        {
            //then our checkpoint is equal to the game object that is named in out save file or the float x,y,z
            //our transform.position is equal to that of the checkpoint or to the float x,y,z
        }
        */
        #endregion
    }


    #endregion
    #region Update
    private void Update()
    {
        if (playerStats.healthCurrent <= 0) //if our characters health is less than or equal to 0
        {
            transform.position = currentCheckpoint.position; //our transform.position is equal to that of the checkpoint or float x,y,z
            playerStats.healthCurrent = playerStats.healthMax; //our characters health is equal to full health
             //character is alive
            //characters controller is active
        }
    }
    
    		
    #endregion
    #region OnTriggerEnter
    private void OnTriggerEnter(Collider other) //Collider other
    {
        if (other.gameObject.CompareTag("Checkpoint")) //if our other objects tag when compared is CheckPoint
        {
            currentCheckpoint = other.transform; //our checkpoint is equal to the other objects transform
            Save.SaveData(playerStats); //save our SpawnPoint as the name of the check point or float x,y,z
        }
    }
    #endregion
}





