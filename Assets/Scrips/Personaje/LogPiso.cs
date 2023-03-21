using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPiso : MonoBehaviour
{

    public Movimiento movimiento;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        movimiento.PuedoSaltar=true;
        

    }
    private void OnTriggerExit (Collider other)
    {
        movimiento.PuedoSaltar = false;
    }
}
