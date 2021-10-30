using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaGirl : MonoBehaviour
{
    //[SerializeField] private LayerMask Tilemap;
    public float speed, jumpForce, move;
    Animator anim;
    SpriteRenderer rend;
    Rigidbody2D rb;
    //BoxCollider2D box;
    void Start()
    {
        //box = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        move = Input.GetAxisRaw("Horizontal") * speed;
    }


    private void FixedUpdate()
    {

        transform.position += new Vector3(move * Time.deltaTime, 0, 0);
        
        
        if (move > 0)
        {
            anim.SetFloat("run", move);
            rend.flipX = false;
        }
        if (move < 0)
        {
            anim.SetFloat("idle", move);
            rend.flipX = true;
        }




        if (Input.GetButtonDown("Jump"))
        {
            
            rb.velocity = new Vector3(0, jumpForce, 0);
        }
    }


    

    /*private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(box.bounds.center, new Vector3(box.bounds.size.x - boon, box.bounds.size.y, box.bounds.size.z), 0f, Vector2.down, height, Tilemap);

        return raycastHit.collider != null;
    }*/
}
