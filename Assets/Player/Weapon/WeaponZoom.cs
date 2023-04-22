using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{

    [SerializeField] private float zoomFOV = 20;
    [SerializeField] private float zoomSensitivity = 0.5f;
    [SerializeField] private Camera camera;
    [SerializeField] private RigidbodyFirstPersonController fpsController;
    
    private float orginalFOV;
    private float originalSensitvity;
    private bool zoomedInToggle = false;

    private void OnDisable()
    {
        ZoomOut(); //make sure to zoom out
    }

    // Start is called before the first frame update
    void Start()
    { 
        originalSensitvity = fpsController.mouseLook.XSensitivity;
        orginalFOV = camera.fieldOfView;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(!zoomedInToggle) //zoom in
            {
                ZooomIn();
            }
            else//zoom out
            {
                ZoomOut();

            }
        }
    }
    private void ZooomIn()
    {
        zoomedInToggle = true;
        camera.fieldOfView = zoomFOV;
        fpsController.mouseLook.XSensitivity = zoomSensitivity;
        fpsController.mouseLook.YSensitivity = zoomSensitivity;
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        camera.fieldOfView = orginalFOV;
        fpsController.mouseLook.XSensitivity = originalSensitvity;
        fpsController.mouseLook.YSensitivity = originalSensitvity;
    }






}
