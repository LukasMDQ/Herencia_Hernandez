using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    //efectos
    public GameObject efectoMuerte;
    public GameObject efectoGolpe;
    public GameObject efectoGolpe2;
    //audio
    public AudioSource _audSource;
    public AudioClip _Clip_Muerte;
    public AudioClip _Clip_hit;
    public Animator ani;
    //-----HUD 
    public  int SubeExp = 0;
    public  int cantKills = 0;
    //BarraVida
    public int vida = 100;
    public float vidaActual;
    public Image barraVida;



    void Start()
    {
        vidaActual = vida;
    }

    void Update()
    {
             
        barraVida.fillAmount = vidaActual / vida;
        muerteEnemigo();
    }
    void muerteEnemigo()
    {
        if (vidaActual <=0)
        {
            cantKills +=1;
            SubeExp +=1;
            AudioSound(_Clip_Muerte);
            // ani.SetTrigger("deadZ");
            GameObject explosionEnemigo  = Instantiate(efectoMuerte,transform.position,transform.rotation);
            Destroy(explosionEnemigo,0.2f);
            Destroy(gameObject,0.2f);
        }
    }
    void AudioSound(AudioClip _Clip_Test)
    {
        _audSource.clip = _Clip_Test;
        _audSource.Play();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag ("espada"))
        {
            //GameObject efectoGolpe = Instantiate(efectoMuerte, transform.position, transform.rotation);
           //Destroy(efectoGolpe, 0.2f);
            AudioSound(_Clip_hit);
            Debug.Log("HIT");
            vidaActual -=30;

        }
    }
}
