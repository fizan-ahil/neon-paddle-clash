using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UIElements;
using UnityEngine.SocialPlatforms.Impl;

public class Ballbounce : MonoBehaviour
{
    public GameObject hitSFX;
    public Ball ball;
    public ScoreManager scoremanager;
    private void bounce(Collision2D collision)
    {
        Vector3 ballposition = transform.position;//to get the position of the ball
        Vector3 racketposition = collision.transform.position;//getting the position of th object our ball has collided wiht.
        float racketheight = collision.collider.bounds.size.y;//to know which part of the racket did the ball hit.

        //toknow if tha ball collided with player1 or player2
        float positionx;
        if(collision.gameObject.name == "Player")
        {
            positionx = 1;
        }
        else
        {
           positionx = -1;
        }

        float positiony = (ballposition.y - racketposition.y) / racketheight;
        
        ball.increasehitcount();
        ball.moveball(new Vector2(positionx,positiony));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if ball had collided with player1 or player2 object
        if(collision.gameObject.name == "Player" || collision.gameObject.name == "AI")
        {
            bounce(collision);
        }
        else if(collision.gameObject.name == "Rightborder")
        {
            scoremanager.player1goal();
            ball.player1start = false;//since player 1 scored a point. so the ball should go to the right on the next start.
            StartCoroutine(ball.Launch());

        }
        else if(collision.gameObject.name == "Leftborder")
        {
            scoremanager.player2goal();
            ball.player1start = true;//since player 2 scored a point. so the ball should go to the left on the next start.
            StartCoroutine(ball.Launch());
        }

        Instantiate(hitSFX,transform.position,transform.rotation);//instantiate fitSFX gameobject whenver there is a collision.
    }
}
