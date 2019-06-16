using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Allow us to interact with UI elements

[AddComponentMenu("Intro PRG/RPG/Player/Health")] //this script can be found in the Component section under the option Intro PRG/Player/Health

public class HeartHealth : MonoBehaviour
{
    [Header("Player Stats")]
    public int maxHealth; //public maxHealth
    public float currentHealth; //public curHealth

    float prevHealth;

    [Header("Heart Slots")]
    public Image[] heartSlots; //Canvas Image heartSlots array
    public Sprite[] hearts; //Sprite hearts array
    public Image heartPrefab;
    public float heartSpacing;
    private float healthPerSection; //private percent healthPerSection


    public Vector2Int heartGridSize;
    public RectTransform heartGridOrigin;

    #region Start
    private void Start()
    {
        prevHealth = currentHealth;

        UpdateHearts(); // Run UpdateHearts
    }
    #endregion

    #region Update
    private void Update()
    {

        if (currentHealth != prevHealth)
        {
            UpdateHearts(); // Run UpdateHearts
        }
        prevHealth = currentHealth;

    }
    #endregion

    
    #region UpdateHearts
    void UpdateHearts()
    {

        
        //calculate the health points per heart section
        healthPerSection = maxHealth / (heartSlots.Length * 4);

        int i = 0; //index variable starting at 0 for slot checks

        foreach (Image slot in heartSlots) //foreach Image slot in heartSlots
        {

            if (currentHealth >= ((healthPerSection * 4)) + healthPerSection * 4 * i) //if curHealth is greater or equal to full for this slot amount
            {
                heartSlots[i].sprite = hearts[0]; //Set heart to 4/4
            }
            else if (currentHealth >= ((healthPerSection * 3)) + healthPerSection * 4 * i) //else if curHealth is greater or equal to 3/4 for this slot amount
            {
                heartSlots[i].sprite = hearts[1]; //Set Heart to 3/4
            }
            else if (currentHealth >= ((healthPerSection * 2)) + healthPerSection * 4 * i) //else if curHealth is greater or equal to 2/4 for this slot amount
            {
                heartSlots[i].sprite = hearts[2]; //Set Heart to 2/4
            }
            else if (currentHealth >= ((healthPerSection * 1)) + healthPerSection * 4 * i) //else if curHealth is greater or equal to 1/4 for this slot amount
            {
                heartSlots[i].sprite = hearts[3]; //Set Heart to 1/4
            }
            else //else
            {
                heartSlots[i].sprite = hearts[4]; //we are empty
            }

            i++; //after checking this slot increase slot index
        }
    }
    #endregion
    
    /*
    void UpdateHeartGrid()
    {
        //heartSlots = new Transform[heartGridSize.x * heartGridSize.y];

        for (int iy = 0; iy < heartGridSize.y; iy++)
        {
            for (int ix = 0; ix < heartGridSize.x; ix++)
            {
                //print("X = " + ix + ", Y = " + iy);
                Instantiate(heartPrefab, new Vector3(ix * heartSpacing, iy * heartSpacing, 0), Quaternion.identity, heartGridOrigin); // Instantiate heart in grid arrangement based on ix and iy



                // Assign heart to next grid slot
                // Determine heart image
            }
        }

        //calculate the health points per heart section
        healthPerSection = maxHealth / (heartSlots.Length * 4);

        int i = 0; //index variable starting at 0 for slot checks

        foreach (Image slot in heartSlots) //foreach Image slot in heartSlots
        {

            if (currentHealth >= ((healthPerSection * 4)) + healthPerSection * 4 * i) //if curHealth is greater or equal to full for this slot amount
            {
                heartSlots[i].sprite = hearts[0]; //Set heart to 4/4
            }
            else if (currentHealth >= ((healthPerSection * 3)) + healthPerSection * 4 * i) //else if curHealth is greater or equal to 3/4 for this slot amount
            {
                heartSlots[i].sprite = hearts[1]; //Set Heart to 3/4
            }
            else if (currentHealth >= ((healthPerSection * 2)) + healthPerSection * 4 * i) //else if curHealth is greater or equal to 2/4 for this slot amount
            {
                heartSlots[i].sprite = hearts[2]; //Set Heart to 2/4
            }
            else if (currentHealth >= ((healthPerSection * 1)) + healthPerSection * 4 * i) //else if curHealth is greater or equal to 1/4 for this slot amount
            {
                heartSlots[i].sprite = hearts[3]; //Set Heart to 1/4
            }
            else //else
            {
                heartSlots[i].sprite = hearts[4]; //we are empty
            }

            i++; //after checking this slot increase slot index
        }
    }
    */
}
