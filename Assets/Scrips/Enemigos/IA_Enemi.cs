using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public enum estados
{
    estatico,ataque
}

public class IA_Enemi : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemigo;
    public float Speed = 1;
    public estados EstadoEnemigo;
    public NavMeshAgent Agente;
    public float RangoVision;
    public Animator ani;
    public Rigidbody rb;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        Comportamiento();
    }
    private void Look()

    {
        Enemigo.transform.LookAt(Player.transform.position);
    }
     
    public void Comportamiento()
    {
        switch (EstadoEnemigo)
        {
            case estados.estatico:
                Look();
                break;
            case estados.ataque:
                EnemiIA();
                break;
        }
    }
    public void EnemiIA()
    {
        RangoVision = Vector3.Distance(Player.transform.position, Enemigo.transform.position);
        if (RangoVision <= 12)
        {
            ani.SetBool("run", true);
            Debug.Log("Te tengo bastardo ! ");
            Agente.SetDestination(Player.transform.position);
        }
        
    }
    
}
