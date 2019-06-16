using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderDelayHealthMeter : MonoBehaviour
{

    // Max health
    // Current health
    // Delayed health value
    // Rate at which delay meter shrinks

    public float healthMax;
    public float healthCurrent;
    public float meterDepleteRate;

    float healthDepleting;
    float healthPrev;

    [Header("References")]
    public Slider healthMeter;
    public Image healthFill;
    public Slider depleteMeter;
    public Image depleteFill;

    PlayerManager healthData;



    // Use this for initialization
    void Start()
    {
        healthData = GetComponent<PlayerManager>();
        UpdateMeter();
    }

    // Update is called once per frame
    void Update()
    {
        healthCurrent = healthData.healthCurrent;
        healthMax = healthData.healthMax;

        if (healthCurrent != healthPrev)
        {
            UpdateMeter();
            print("Health changed!");
        }

        healthPrev = healthCurrent;

        if (healthDepleting > healthCurrent)
        {
            healthDepleting -= meterDepleteRate * Time.deltaTime;
        }
        healthDepleting = Mathf.Clamp(healthDepleting, healthCurrent, healthMax);
        depleteMeter.GetComponent<Slider>().value = Mathf.Clamp01(healthDepleting / healthMax);

        

    }

    void UpdateMeter()
    {
        if (healthCurrent <= 0)
        {
            healthFill.enabled = false;
        }
        else if (healthCurrent > 0)
        {
            healthFill.enabled = true;
        }
        healthMeter.GetComponent<Slider>().value = Mathf.Clamp01(healthCurrent / healthMax);

    }
}
