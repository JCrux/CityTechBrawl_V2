using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat_Script : MonoBehaviour
    
{
    public Collider2D hitbox;
    public Collider2D hitboxK;

    public Animator anim;
    float timer = 3f;
    // Start is called before the first frame update
    void Start() 
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
                Debug.Log(timer);
            }

            if (timer <= 0)
            {
                Kick();
            }


        }




    }
    void Punch()
{
    //play attack animation
     anim.SetTrigger("punch1");
        Debug.Log("punch1");

        
}
    void Kick()
    {
        anim.SetTrigger("kick1");
           Debug.Log("kick1");
    }

    void buttonPress() 
    {
    


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log(" ow that hurt"); //collision.gameObject.SendMessage("ApplyDamage", 10);
        }
    }
}

