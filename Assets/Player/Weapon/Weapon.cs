using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera FPCamera;

    [SerializeField] private float range = 100f;
    [SerializeField] private float damage = 30f;

    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitEffects;

    [SerializeField] private Ammo ammoSlot;
    [SerializeField] private AmmoType ammoType;

    [SerializeField] private float timeBetweenShots = 0.5f;

    [SerializeField] private TextMeshProUGUI ammoText;

    private bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }

    }

    private void DisplayAmmo()
    {
        int currAmmoAmount = ammoSlot.GetCurrAmmo(ammoType);
        ammoText.text = currAmmoAmount.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetCurrAmmo(ammoType) > 0)
        {
            ammoSlot.ReduceCurrentAmmo(ammoType);
            PlayMuzzleFlash();
            ProccessRaycast();
        }

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProccessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {

            CreateHitImpact(hit);


            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; } //if the target was not an enemyx
            target.TakeDamage(damage);
        }
        else//if player hits nothing
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffects, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
