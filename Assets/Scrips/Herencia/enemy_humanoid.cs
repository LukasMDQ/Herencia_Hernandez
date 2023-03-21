
using UnityEngine;

public class enemy_humanoid : enemy_Control
{     
      
    void Update()
    {
       Enemy_Status();
       death();
       // HP.fillAmount = maxHp / hp;//la barra de vida bajara en funcion al daño recibido.
       // EXP.fillAmount = maxExp / exp;// la barra de experiencia bajara en funcion al daño recibido.
        //lvlUP();
    }
   
}
