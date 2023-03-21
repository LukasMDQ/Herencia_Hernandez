using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float range=100;
    public Camera MovCam;
    public PickUp pickup;
    public bool ArmaDist;
    Animator anDisp;



    //Efectos
    public GameObject inpactEffect;
    public GameObject inpactEffect2;
    public ParticleSystem FlashEffect;
    public AudioSource _audSource;
    public AudioClip _Clip_Disparo;
    public AudioClip _Clip_Impact;
    
    public VidaEnemigo vidaEnemigo;
    public VidaAlfa vidaAlfa;

    //public AudioClip _Clip_ObjectInpact;



    void Update()
    {
        //InputDisparo();
    }
    void InputDisparo()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
           //Disparar();
           // disparo1();
           
            FlashEffect.Play();
        }
    } 
    public void disparo()
    {
        
        RaycastHit hit;
       // AudioDisparo( _Clip_Disparo );
        if (Physics.Raycast(MovCam.transform.position,MovCam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Enemi")
            {
                AudioDisparo(_Clip_Disparo);
                hit.transform.gameObject.GetComponent<VidaEnemigo>().vidaActual -= 30;
                hit.transform.gameObject.GetComponent<VidaAlfa>().vidaActual -= 30;
                AudioDisparo (_Clip_Impact );
                AudioDisparo(_Clip_Disparo);
                Debug.Log ("EN EL BLANCO !!!");
                GameObject Inpacto1 = Instantiate(inpactEffect , hit.point,Quaternion.LookRotation(hit.normal));
                Destroy(Inpacto1,2f);
                GameObject Inpacto2 = Instantiate(inpactEffect2, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(Inpacto2, 2f);
            }
            if (hit.transform.tag == "EnemiAlfa")
            {
                AudioDisparo(_Clip_Disparo);
                hit.transform.gameObject.GetComponent<VidaAlfa>().vidaActual -= 30;
                AudioDisparo(_Clip_Impact);
                AudioDisparo(_Clip_Disparo);
                Debug.Log("EN EL BLANCO !!!");
                GameObject Inpacto1 = Instantiate(inpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(Inpacto1, 2f);
                GameObject Inpacto2 = Instantiate(inpactEffect2, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(Inpacto2, 2f);
            }
            /* if (hit.transform.tag == "piso")
             {
                 AudioDisparo(_Clip_ObjectInpact);

                 GameObject InpactoGO = Instantiate(inpactEffect2, hit.point, Quaternion.LookRotation(hit.normal));
                 Destroy(InpactoGO, 2f);
             }
             if (hit.transform.tag == "objeto")
             {
                 AudioDisparo(_Clip_Disparo);

                 GameObject InpactoGO = Instantiate(inpactEffect2, hit.point, Quaternion.LookRotation(hit.normal));
                 Destroy(InpactoGO, 2f);
             }*/

        }
        
    }
     
    void AudioDisparo (AudioClip _Clip_Test)
    {
        _audSource.clip= _Clip_Test;
        _audSource.Play();
    }
    
    
}
