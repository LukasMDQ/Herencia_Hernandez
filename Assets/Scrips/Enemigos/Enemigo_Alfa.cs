using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo_Alfa : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public Rigidbody rb;
    public GameObject target;
    public NavMeshAgent Agente;
    public float Speed;
    public Disparo disparo;
    public VidaAlfa vidaAlfa;

    private void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Personaje");
    }
    void Update()
    {
        Comportamiento_Enemigo();
        hostil();
        if (vidaAlfa.vida <= 0)
        {
            Speed = 0;
        }
    }
    public void Comportamiento_Enemigo()
    {
        if(Vector3.Distance(transform.position,target.transform.position)>10)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            Debug.Log("CARNEEE ! ");
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation, 2 ) ;
            ani.SetBool("walk", false);
            ani.SetBool("run", true);
            transform.Translate(Vector3.forward * Speed * 2 * Time.deltaTime);
            if (Vector3.Distance(transform.position, target.transform.position) <=2)
            {
                ani.SetTrigger("attackZ");
            }
        }
        
    }
    void hostil()
    {
        if (vidaAlfa.vidaActual <= 450)
        {
            Debug.Log("CARNEEE ! ");
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            ani.SetBool("walk", false);
            ani.SetBool("run", true);
            transform.Translate(Vector3.forward * Speed * 2 * Time.deltaTime);
            if (Vector3.Distance(transform.position, target.transform.position) <= 2)
            {
                ani.SetTrigger("attackZ");
            }

        }
                          
    }
      
}
