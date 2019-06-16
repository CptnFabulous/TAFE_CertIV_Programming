using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthMeter : MonoBehaviour
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
    public Camera view;
    public Canvas meterCanvas;
    public Slider healthMeter;
    public Image healthFill;
    public Slider depleteMeter;
    public Image depleteFill;



    // Use this for initialization
    void Start()
    {
        UpdateMeter();
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

        if (healthDepleting > healthCurrent)
        {
            healthDepleting -= meterDepleteRate * Time.deltaTime;
        }
        healthDepleting = Mathf.Clamp(healthDepleting, healthCurrent, healthMax);
        depleteMeter.GetComponent<Slider>().value = Mathf.Clamp01(healthDepleting / healthMax);

        Quaternion cameraPosition = Quaternion.Euler(view.transform.rotation.x, view.transform.rotation.y + 180, view.transform.rotation.z);
        meterCanvas.transform.LookAt(view.transform);
    }

    void UpdateMeter()
    {
        healthMeter.GetComponent<Slider>().value = Mathf.Clamp01(healthCurrent / healthMax);
        if (healthCurrent <= 0)
        {
            healthFill.enabled = false;
        }
        else if (healthCurrent > 0)
        {
            healthFill.enabled = true;
        }
    }
}
