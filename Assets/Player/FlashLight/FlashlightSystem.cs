using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] private float lightDecay = .1f;
    [SerializeField] private float angleDecay = 1f;
    [SerializeField] private float minimumAngle = 40f;

    private Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntesinty();
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle) { return; }

        myLight.spotAngle -= angleDecay * Time.deltaTime;

    }

    private void DecreaseLightIntesinty()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }
    public void AddLightIntensity(float intesintyAmount)
    {
        myLight.intensity += intesintyAmount;

    }
}
