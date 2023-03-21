
using JetBrains.Annotations;
using UnityEngine;

    
public class Movimiento : MonoBehaviour
{    
     public float Speed = 5f;
     public float Fuerza = 1f;
     public float RotSpeed = 1.0f;
    //animations
     Animator anima;
     private float x, y;
     public Rigidbody rb;
     public float SprintSpeed = 10;
     public float RotationSpeed = 200f;
     //Salto//
     public int GravCaida = 0;
     public bool PuedoSaltar;
     public float FuerzaSalto = 6f;
     public float CantSaltos = 2f;
     //Ataques//
     public Disparo disparo;
     public bool armaDist;
     public bool Espada_1M;
     public bool atacando;
     public bool avanzaGolpe;
     public float inpulsoGolpe = 10f;
    
     void Start()
     {
         PuedoSaltar = false;
         anima = GetComponent <Animator>();
     }
    
     void Update()
     {
        CambioAtaque();//CAMBIO ATAQUES//
        RotacionMouse();//ROTACION MOUSE//
        BloqueoCusor();//BLOQUEO CURSOR//
        MovClasico();//MOVIMIENTO//
        Saltar();//SALTO//
        Sprint();//SPRINT//
        AtaqueMele();//ATAQUE CUERPO A CUERPO//
        AtaqueDistancia();//ATAQUE A DISTANCIA//

     }
     private void FixedUpdate()
     {
        if (avanzaGolpe) 
        {
            rb.velocity = transform.forward * inpulsoGolpe*Speed;
        }
        if (!atacando)
        {
            MovClasico();
        }
    }
     //------------FRAMES_ANIMACION-----//
     public void AvanzoSolo()
     {
        avanzaGolpe= true;

     }
     public void DejoAvanzar()
    {
        avanzaGolpe= false;
    }
     public void NoGolpeo()
     {
        atacando = false;
     }           

     //-----------METODOS-------------//
        
     public void AtaqueMele()//------------------ATAQUE_MELE---------------//
     {
        //Ataque Espada
        if (Input.GetKeyDown(KeyCode.Mouse0) && PuedoSaltar && !atacando && !armaDist && Espada_1M) 
        {
                anima.SetTrigger("GolpeEspada");
                atacando= true;                   
        }
        //Patada
        if (Input.GetKeyDown(KeyCode.F) && PuedoSaltar && !atacando  )
        {                  
                anima.SetTrigger("patada");
                atacando = true;                     
        }
        //Ataque a puño
        if (Input.GetKeyDown(KeyCode.Mouse0) && PuedoSaltar && !atacando && !armaDist && !Espada_1M)
        {
                anima.SetTrigger("golpeo");
                atacando = true;
        }

     }        
     public void MovPhysic()//-------------------MOVIMIENTO+FISICAS--------//
     {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3(horizontal, 0, vertical);
        rb.AddForce(moveInput * Speed * Time.deltaTime);
        //AnimacionMov//
        anima.SetFloat("velX", horizontal);
        anima.SetFloat("velY", vertical);
     }
     public void Saltar()//----------------------SALTO+ANIMACION-----------//

     {
        if (PuedoSaltar == true)
        {   
               if (!atacando)
               {
                    if (Input.GetKeyDown(KeyCode.Space))// && CantSaltos<=2
                {
                        
                        anima.SetBool("salto", true);
                        rb.AddForce(new Vector3(0, FuerzaSalto*Fuerza, 0), ForceMode.Impulse);
                       // CantSaltos = CantSaltos + 1;             
                    }
               }
               
               anima.SetBool("piso", true);
        }
        else
        {
            Caida();
        }
     }
     public void Caida()//-----------------------CAIDA---------------------//
     {
         rb.AddForce(GravCaida *Physics.gravity);//CAER RAPIDO//
         anima.SetBool("piso", false);
         anima.SetBool("salto", false);
     }
     public void MovClasico()//------------------MOVIMIENTO----------------//
     {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x, 0 * Time.deltaTime * RotSpeed);
        transform.Translate(0, 0, y * Time.deltaTime * Speed);

        anima.SetFloat("velX", x);
        anima.SetFloat("velY", y);

     }
     public void CambioAtaque()//----------------CAMBIO DE ARMA--------//
     {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Espada_1M = true;
            armaDist = false;
            AtaqueMele();
            anima.SetTrigger("SacEsp");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            armaDist = true;
            Espada_1M = false;
            anima.SetTrigger("SacArc");
        }
    }    
     public void Sprint()//----------------------SPRINT+FUERZA-------------//
     {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = SprintSpeed;
            FuerzaSalto = 10f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = 5;
            FuerzaSalto = 7;
        }
     }
     public void RotacionMouse()//---------------ROTACION MOUSE------------//
     {
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed, 0));
     }
     public void BloqueoCusor()//----------------BLOQUEAR CURSOR-----------//
     {
       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            atacando = true;
        }
        else
        {
            atacando = false;
        }
     }
     public void AtaqueDistancia()//-------------ATAQUE_DISTANCIA----------//
     {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && PuedoSaltar && !atacando && !Espada_1M && armaDist)
        {           
                
                anima.SetTrigger("Disp");
                disparo.disparo();
                atacando = true;
            
        }
     }
}
   