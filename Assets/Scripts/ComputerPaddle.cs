using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
   public Rigidbody2D ball;
   private void FixedUpdate()
   {
      if (this.ball.velocity.x > 0.0f)
      {
         if (this.ball.position.y > this.transform.position.y)
         {
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
            rigidbody.AddForce(Vector2.down * this.speed);
         }
         else if (this.transform.position.y < 0.0f)
         {
            rigidbody.AddForce(Vector2.up * this.speed);
         }
      }
   }
}
