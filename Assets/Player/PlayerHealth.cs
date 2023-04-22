using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeathHandler))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHitPoints = 100f;
    [SerializeField] private float currHitPoints = 0;


   
    private void Start()
    {
        currHitPoints = maxHitPoints;
    }


    public void TakeDamage(float amount)
    {
        amount = Mathf.Abs(amount);
        currHitPoints -= amount;
        if (currHitPoints <= 0f)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
