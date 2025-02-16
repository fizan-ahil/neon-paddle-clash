using UnityEngine;
using UnityEngine.Rendering;

public class player1 : MonoBehaviour
{
    public float racketspeed;
    private Rigidbody2D rb;
    private Vector2 racketdirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directiony = Input.GetAxisRaw("Vertical");
        Debug.Log("Player1: " + directiony);  // Log the input value
        racketdirection = new Vector2(0,directiony).normalized;
    }

    private void FixedUpdate()//called once per physics frame. anything that we do in rigidboyd 2d we do in fixedupdate 
    {
        rb.velocity = racketdirection * racketspeed;//applying racketspeed variable to the physics aspect aspect of our racket which is the rigidbody2d
    }
}
