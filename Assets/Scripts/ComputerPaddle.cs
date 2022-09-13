using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
   public Rigidbody2D ball;
   private void FixedUpdate()
   {
      if (this.ball.velocity.x > 0.0f) // The ball is coming toward the computer paddle
      {
         if (this.ball.position.y > this.transform.position.y)
         {
            // We use AddForce here to prevent a "laggy" paddle, he can adjust it
            // alot faster than the player
            rigidbody.AddForce(Vector2.up * this.speed);
         }
         else if (this.ball.position.y < this.transform.position.y)
         {
            rigidbody.AddForce(Vector2.down * this.speed);
         }
      }
      else
      {
         if (this.transform.position.y > 0.0f)
         {
            rigidbody.AddForce(Vector2.down * this.speed / 2);
         }
         else if (this.transform.position.y < 0.0f)
         {
            rigidbody.AddForce(Vector2.up * this.speed / 2);
         }
         else {
            rigidbody.velocity = Vector2.zero;
         }
      }
   }

   private void OnCollisionEnter2D(Collision2D collision)
    {
      base.OnCollisionEnter2D(collision);
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ball.SwitchToComputerMaterial();
        }
    }
}
