using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class Hero : MonoBehaviour
{
    [SerializeField] private float speed= 3f;
    [SerializeField] private int lives =5;
    [SerializeField] private float jumpForce= 15f;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anima;

    private States State{
        get { return (States)anima.GetInteger("state");}
        set { anima.SetInteger("state", (int)value); }
    }

     private void Awake(){
         rb = GetComponent<Rigidbody2D>();
         sprite = GetComponentInChildren<SpriteRenderer>();
         anima = GetComponent<Animator>();
         }
    private void Run(){

        Vector3 dir =  transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

       sprite.flipX = dir.x < 0.0f;

       if(isGrounded) State = States.run;

       Debug.Log(String.Format("{0} {1}",sprite.flipX,dir.x));
    
    }
     
    private void Jump(){
        rb.AddForce(transform.up * jumpForce,ForceMode2D.Impulse);
    } 

    private void CheckGround(){
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.9f);
        isGrounded = collider.Length > 1;
        if(rb.velocity.y>0) State = States.jump;
        else if (rb.velocity.y<0) State = States.fall;
        //Debug.Log(String.Format("{0} {1}",isGrounded,State));
    }

    void Start()
    {
        
    }

    private void FixedUpdate(){
        CheckGround();
    }

    private void Update()
    {
        if(isGrounded) 
            State = States.anim;

        if(Input.GetButton("Horizontal"))
            Run();
        if(isGrounded && Input.GetButtonDown("Jump"))
            Jump();
    }
}

public enum States{
    anim=0,
    run,
    jump,
    fall
}