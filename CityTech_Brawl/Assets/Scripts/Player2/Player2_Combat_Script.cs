using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Combat_Script : MonoBehaviour

{
    public Collider2D hitbox2;
    public Collider2D hitboxK2;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Punch();

            hitbox2.enabled = true;

        }

        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            hitbox2.enabled = false;

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Kick();

            hitboxK2.enabled = true;
        }

        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            hitboxK2.enabled = false;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log(" ow that hurt"); //collision.gameObject.SendMessage("ApplyDamage", 10);
        }
    }
}

