using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject[]armas;
    public Movimiento movimiento;
    public Disparo disparo;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) 
        {
            TirarArma();
        }
        
    }
    public void ActivarArma(int numero)
    {
        for (int i = 0 ; i < armas.Length; i++) 
        {
            armas[i].SetActive(false);
        }
        armas[numero].SetActive(true);         
             
    }
    public void TirarArma()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < armas.Length; i++)
            {
                armas[i].SetActive(false);
                movimiento.Espada_1M = false;//desactiva arma a una mano
                movimiento.armaDist = false;//desactiva arma a distancia
            }
        }
       
       
    } 
        
}





