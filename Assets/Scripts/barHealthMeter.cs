using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barHealthMeter : MonoBehaviour
{

    public float healthCurrent;
    public int healthMax;

    public Image healthBar;

    // Use this for initialization
    void Start()
    {
        //meterData = healthBar.GetComponent<Image>();
        //meterData.fillMethod = Image.FillMethod 
        //meterData.type = Image.Type(filled);
        //meterData.fillMethod = Image.FillMethod();

        //healthBar.fillOrigin = 
        //healthBar.fillMethod 

        healthBar.fillMethod = Image.FillMethod.Horizontal;
        //healthBar.fillOrigin = 
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp01(healthCurrent / healthMax);
    }
}
