
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text TextoEXP;
    public Text TextoKills;
    public VidaEnemigo vidaEnemigo;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //barraVida.fillAmount = vidaActual / vida;
        TextoEXP.text = "Experiencia: " + vidaEnemigo.SubeExp;
        TextoKills.text = "Enemigos Abatidos : " + vidaEnemigo.cantKills;
    }
}
