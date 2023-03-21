using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaras : MonoBehaviour
{
    public GameObject ThreePersonCam;
    public GameObject FirstPersonCam;
           
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            CameraChange();
    }
    void CameraChange ()
    {
        if (ThreePersonCam.activeInHierarchy) 
        {   //Si la camara en Tercera persona esta activa, cambia a la de Primera persona// 
            ThreePersonCam.SetActive(false);
            FirstPersonCam.SetActive(true);
        }
        else
        {   //Sino hara lo contrario//
            ThreePersonCam.SetActive(true);
            FirstPersonCam.SetActive(false);
        }
    }

}
