using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour   
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 playerMove;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on " + gameObject.name);
        }
    }

    void Update()
    {
        if(isAI) 
        {
            AIControl();
        }
        else 
        {
            PlayerControl();
        }
    }

    private void PlayerControl()
    {
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }

    private void AIControl()
    {
        if (ball == null) return; // Prevents errors if the ball is missing

        float targetY = Mathf.Lerp(transform.position.y, ball.transform.position.y, Time.deltaTime * movementSpeed);
        playerMove = new Vector2(0, Mathf.Clamp(targetY - transform.position.y, -1, 1));
    }

    private void FixedUpdate() 
    {
        rb.velocity = playerMove * movementSpeed;
    }
}
