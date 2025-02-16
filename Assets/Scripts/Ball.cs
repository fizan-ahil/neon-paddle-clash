using System;
using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startspeed;//starting speed of the ball
    public float extraspeed;//extra speed after it bounces of the racket
    public float maxextraspeed;//to set the max spped. we don't want the speed to keep increasing.
    public Boolean player1start = true;//whenever this is true, we want the player1 to start off with the ball. when this is false we want the player 2 to start of instead.
    private int hitcount = 0;
    private Rigidbody2D rb;//to do physics to move our ball.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    private void restartball()//this will be called whenever the player scores a point.
    {
        rb.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);//to move the ball back to the center.
    }
    public IEnumerator Launch()//to move our ball call moveball() within a coroutine
    {
        restartball();
        hitcount = 0;
        yield return new WaitForSeconds(1);//we want to make the game wait for 1 sec before the ball starts moving.

        if(player1start == true)
        {
            moveball(new Vector2(-1,0));//means the player 1 starting the ball will move to the left
        }
        else
        {
            moveball(new Vector2(1,0));//means the player1start variable is false means player 2 si starting and th ab ll will move to the right.
        }
    }

    public void moveball(Vector2 direction)
    {
        direction = direction.normalized;
        float ballspeed = startspeed + hitcount * extraspeed; //determine current speed and increases as rhe ball hots the racket.
        rb.velocity = direction * ballspeed;//apply this ballspeed to the physics aspect of ball whic is rigidboyd2d
    }

    public void increasehitcount()
    {
        if(hitcount * extraspeed < maxextraspeed)
        {
            hitcount++;
        }
    }
}
