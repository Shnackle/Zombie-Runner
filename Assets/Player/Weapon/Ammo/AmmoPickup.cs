using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private int AmmoAmount;

    private void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.tag == "Player")
        {
            Ammo ammo = other.GetComponent<Ammo>();
            ammo.IncreaseCurrentAmmo(ammoType, AmmoAmount);
            Debug.Log("player has picked up ammo");
            Destroy(gameObject);
        }    
    }
}
