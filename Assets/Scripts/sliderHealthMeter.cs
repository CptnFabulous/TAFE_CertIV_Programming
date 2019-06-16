using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderHealthMeter : MonoBehaviour
{
    [Header("Player stats")]
    public int healthMax; // Player's maximum health
    public float healthCurrent;  // Player's current health
    public float meterShrinkRate;

    float healthPrev;
    float healthDeplete;



    [Header("References")]
    public Slider healthMeter;
    public Image healthFill;
    public Slider depleteMeter;
    public Image depleteFill;


    // Use this for initialization
    void Start()
    {
        healthPrev = healthCurrent;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthCurrent != healthPrev)
        {
            UpdateMeter();
            print("Health changed!");
        }

        healthPrev = healthCurrent;

        if (healthDeplete > healthCurrent)
        {
            healthDeplete -= meterShrinkRate * Time.deltaTime;
            depleteMeter.GetComponent<Slider>().value = Mathf.Clamp01(healthDeplete / healthMax);
        }
        healthDeplete = Mathf.Clamp(healthDeplete, healthCurrent, healthMax);

    }

    void UpdateMeter()
    {
        healthMeter.GetComponent<Slider>().value = Mathf.Clamp01(healthCurrent / healthMax);
        depleteMeter.GetComponent<Slider>().value = Mathf.Clamp01(healthDeplete / healthMax);
        /*
        if (healthCurrent <= 0 && healthFill.enabled)
        {
            healthFill.enabled = false;
            depleteFill.enabled = false;
        }
        else if (healthFill.enabled == false && healthCurrent > 0)
        {
            healthFill.enabled = true;
            depleteFill.enabled = true;
        }
        */

        if (healthCurrent <= 0 && healthFill.enabled)
        {
            healthFill.enabled = false;
            depleteFill.enabled = false;
        }
        else if (healthFill.enabled == false && healthCurrent > 0)
        {
            healthFill.enabled = true;
            depleteFill.enabled = true;
        }

    }
}
