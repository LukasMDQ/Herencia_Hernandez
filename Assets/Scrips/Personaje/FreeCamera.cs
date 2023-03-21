using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
     public float RotationSpeed = 200f;
    public float sensibilidadMouse = 200f;
    public float xRotacion;
    public float yRotacion;
    void Start()
    {
        
    }

    void Update()
    {
        CameraFree();
    }
    //FreeCamera//
    public void CameraFree()
    {  
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            MouseLook();
        }
       

        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(new Vector3(0, 0, -0.1f * Time.deltaTime * RotationSpeed));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(new Vector3(0, 0, 0.1f * Time.deltaTime * RotationSpeed));


        }
    }
   
    void MouseLook()

    {

        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;



        xRotacion -= mouseY;

        xRotacion = Mathf.Clamp(xRotacion, -70, 70);



        yRotacion += mouseX;



        transform.localRotation = Quaternion.Euler(xRotacion, yRotacion, 0);

    }

}
