using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] private float addIntensity = 1f;
    [SerializeField] private float restoreAngle = 90f;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            FlashlightSystem playerLight = other.GetComponentInChildren<FlashlightSystem>();
            playerLight.RestoreLightAngle(restoreAngle);
            playerLight.AddLightIntensity(addIntensity);

            Destroy(gameObject);

        }
    }
}
