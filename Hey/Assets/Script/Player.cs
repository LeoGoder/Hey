using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float sprint;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }


    private void PlayerMovement()
    {
        // Movement in 8 direction 
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");

        Vector2 movHorizontal = transform.right * xMov;
        Vector2 movVertical = transform.up * yMov;

        Vector2 velocity = (movHorizontal + movVertical).normalized * speed;

        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);

        // Player perform a Sprint 

        Vector2 dashVelocity = (movHorizontal + movVertical).normalized * sprint;

        if (Input.GetKey(KeyCode.Space))
        {
            rb2D.MovePosition(rb2D.position + dashVelocity * Time.fixedDeltaTime);
        }
    }

}
