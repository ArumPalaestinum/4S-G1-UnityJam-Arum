using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    //jumping
    public float jump;
   

    //Gravity
    public float waterGravity = 2f;
    public float DefaultGravity;
    private bool inWater;

    //spawn
    Vector2 StartPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        DefaultGravity = rb.gravityScale;

        StartPos = transform.position; 
    }

    private void Update()
    {
        if (inWater == true)
        {
            speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
            speedY = Input.GetAxisRaw("Vertical") * movSpeed;
            rb.velocity = new Vector2(speedX, speedY);
        }
       
    }

    //WaterGravity enter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor")) //for jump
        {
           inWater = false;
           rb.velocity = new Vector2(rb.velocity.x, jump);
           
        }

            if (collision.CompareTag("Enemy")) //death
        {
            Die();
        }

        if (collision.CompareTag("Water"))
        {
            rb.gravityScale = waterGravity;
           // Die(WaitForSeconds, 42f); //HERE IS THE NUMBER BUT I DONT KNOW HOW TO USE IT; I WANT THE PLAYER TO DIE IF THEY'RE $" SECONDS IN THE WATER  s
        }
    }

    // Exit
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            inWater = true;
           
        }

            if (collision.CompareTag("Water"))
        {
                   
            rb.gravityScale = DefaultGravity;
        }
    }

    //death
    void Die()
    {
        Respawn();
    }

    // respawn
    void Respawn()
    {
        transform.position = StartPos;
    }

    

}
