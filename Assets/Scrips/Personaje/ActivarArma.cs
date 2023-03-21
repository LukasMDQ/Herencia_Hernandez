using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivarArma : MonoBehaviour
{
    public PickUp pickUp;
    public int numeroArma;
    public GameObject Botton;
    void Start()
    {
        pickUp = GameObject.FindGameObjectWithTag("Personaje").GetComponent<PickUp>();
    }     
  
    private void OnCollisionStay(Collision other)
    {
       
        if (other.gameObject.name == "Personaje") //&& Input.GetKeyDown(KeyCode.G)
        {
            Botton.SetActive(true);
            pickUp.ActivarArma(numeroArma);
            Destroy(gameObject);
        }
        else
        {
            Botton.SetActive(false);
        }
        
     }
   
}
