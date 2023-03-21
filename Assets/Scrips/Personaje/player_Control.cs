
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class player_Control : MonoBehaviour
{    //stats
     public float Speed = 5f;
     public float Str = 1f;
     public float RotSpeed = 1.0f;
     public float SprintSpeed = 10;
     public float RotationSpeed = 200f;
          
     //animation
     Animator anim;
     private float x, y;
     //Physics
     public Rigidbody rb;
      
     //Jump
     public int GravFall = 0;
     public bool canJump;
     public float JumpStr = 6f;
   
     //Attacks//
     public Disparo disparo;
     public bool weaponDist;
     public bool weaponMele;
     public bool attack;
     public bool advanceAttack;
     public float inpulseHit = 10f;
     //info
    
     void Start()
     {
         canJump = false;
         anim = GetComponent <Animator>();
     }
    
     void Update()
     {
        ChangeAttack();//CAMBIO ATAQUES//
        MouseRot();//ROTACION MOUSE//
        BlockCusor();//BLOQUEO CURSOR//
        MovClassic();//MOVIMIENTO//
        Jump();//SALTO//
        Sprint();//SPRINT//
        MeleAttack();//ATAQUE CUERPO A CUERPO//
        DistanceAttack();//ATAQUE A DISTANCIA//

     }
     private void FixedUpdate()
     {
        if (advanceAttack) 
        {
            rb.velocity = transform.forward * inpulseHit *Speed;
        }
        if (!attack)
        {
            MovClassic();
        }
     }
     //------------FRAMES_ANIMACION-----//
     public void Advance()
     {
        advanceAttack = true;

     }
     public void DejoAvanzar()
     {
        advanceAttack = false;
     }
     public void NoGolpeo()
     {
        attack = false;
     }           

     //-----------METODOS-------------//
        
     public void MeleAttack()//------------------ATAQUE_MELE---------------//
     {
        //Ataque Espada
        if (Input.GetKeyDown(KeyCode.Mouse0) && canJump && !attack && !weaponDist && weaponMele) 
        {
                anim.SetTrigger("GolpeEspada");
                attack= true;                   
        }
        //Patada
        if (Input.GetKeyDown(KeyCode.F) && canJump && !attack  )
        {                  
                anim.SetTrigger("patada");
                attack = true;                     
        }
        //Ataque a pu�o
        if (Input.GetKeyDown(KeyCode.Mouse0) && canJump && !attack && !weaponDist && !weaponMele)
        {
                anim.SetTrigger("golpeo");
                attack = true;
        }

     }        
     public void MovPhysic()//-------------------MOVIMIENTO+FISICAS--------//
     {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3(horizontal, 0, vertical);
        rb.AddForce(moveInput * Speed * Time.deltaTime);
        //AnimacionMov//
        anim.SetFloat("velX", horizontal);
        anim.SetFloat("velY", vertical);
     }
     public void Jump()//----------------------SALTO+ANIMACION-----------//

     {
        if (canJump == true)
        {   
               if (!attack)
               {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        
                        anim.SetBool("salto", true);
                        rb.AddForce(new Vector3(0, JumpStr*Str, 0), ForceMode.Impulse);
                                   
                    }
               }
               
               anim.SetBool("piso", true);
        }
        else
        {
            Fall();
        }
     }
     public void Fall()//-----------------------CAIDA---------------------//
     {
         rb.AddForce(GravFall *Physics.gravity);//CAER RAPIDO//
         anim.SetBool("piso", false);
         anim.SetBool("salto", false);
     }
     public void MovClassic()//------------------MOVIMIENTO----------------//
     {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x, 0 * Time.deltaTime * RotSpeed);
        transform.Translate(0, 0, y * Time.deltaTime * Speed);

        anim.SetFloat("velX", x);
        anim.SetFloat("velY", y);

     }
     public void ChangeAttack()//----------------CAMBIO DE ARMA--------//
     {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponMele = true;
            weaponDist = false;
            MeleAttack();
            anim.SetTrigger("SacEsp");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponDist = true;
            weaponMele = false;
            anim.SetTrigger("SacArc");
        }
    }    
     public void Sprint()//----------------------SPRINT+FUERZA-------------//
     {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = SprintSpeed;
            JumpStr = 10f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = 5;
            JumpStr = 7;
        }
     }
     public void MouseRot()//---------------ROTACION MOUSE------------//
     {
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed, 0));
     }
     public void BlockCusor()//----------------BLOQUEAR CURSOR-----------//
     {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (Input.GetKey(KeyCode.LeftControl))//Mientars se mantenga "Control" el cursor vuelve a la nomalidad
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            attack = true;
        }
        else
        {
            attack = false;
        }
     }
     public void DistanceAttack()//-------------ATAQUE_DISTANCIA----------//
     {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && canJump && !attack && !weaponMele && weaponDist)
        {           
                
                anim.SetTrigger("Disp");
                disparo.disparo();
                attack = true;
            
        }
     }
}








