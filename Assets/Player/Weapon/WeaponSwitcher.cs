using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currWeaponIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }

    // Update is called once per frame
    void Update()
    {
        int prevWeaponIndex = currWeaponIndex;

        ProcessKeyInput();
        ProcessScrollWheel();

        if(prevWeaponIndex != currWeaponIndex)
        {
            SetWeaponActive();
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currWeaponIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currWeaponIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currWeaponIndex = 2;
        }
    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(currWeaponIndex >= transform.childCount - 1)
            {
                currWeaponIndex = 0;
            }
            else
            {
                currWeaponIndex += 1;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(currWeaponIndex == 0)
            {
                currWeaponIndex = transform.childCount - 1;
            }
            else
            {
                currWeaponIndex -= 1;
            }
        }
    }



    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach(Transform weapon in transform)
        {
            if (weaponIndex == currWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex += 1;
        }
    }
}
