using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas GameOverCanvas;

    private void Start()
    {
        GameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        DisableWeapoons();
        GameOverCanvas.enabled = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void DisableWeapoons()
    {
        FindObjectOfType<WeaponSwitcher>().enabled = false;

        WeaponZoom[] zooms = FindObjectsOfType<WeaponZoom>();
        foreach (WeaponZoom zoom in zooms)
        {
            zoom.enabled = false;
        }

        Weapon[] weapons = FindObjectsOfType<Weapon>();
        foreach (Weapon weapon in weapons)
        {
            weapon.enabled = false;
        }
    }
}
