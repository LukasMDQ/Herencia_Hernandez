using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VIDA : MonoBehaviour
{
    public int vida = 100;
    public float vidaActual;
    public Image barraVida;
    public Respawn respawn;
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vida;
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.fillAmount = vidaActual / vida;
        muerte();
    }
    void muerte()
    {
        if (vidaActual<=0)
        {
            Debug.Log("HAS MUERTO");
            respawn.Respawnear();
            vidaActual = vida;
        }
        
    }
     
    private  void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("daño"))
        {
            Debug.Log("Auch");
            vidaActual -= 5;
            

            //GameObject efectoGolpe = Instantiate(efectoMuerte, transform.position, transform.rotation);
            //Destroy(efectoGolpe, 0.2f);
            //AudioSound(_Clip_hit);
        }
        if (other.gameObject.CompareTag("dañoAlfa"))
        {
            Debug.Log("Auch");
            vidaActual -= 10;
            //GameObject efectoGolpe = Instantiate(efectoMuerte, transform.position, transform.rotation);
            //Destroy(efectoGolpe, 0.2f);
            //AudioSound(_Clip_hit);
        }
    }
}
