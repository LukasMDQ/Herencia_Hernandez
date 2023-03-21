using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcDist : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemigo;
    public float dist;
    void Start()
    {
        
    }
    void Update()
    {
        dist = Vector3.Distance(Player.transform.position, Enemigo.transform.position);
        //Debug.Log("Distancia al objetivo: "+ dist);
        if (dist <= 5)
        {
            Debug.Log("Te atrape :F ");
        }
    }
}
