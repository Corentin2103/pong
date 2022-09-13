using UnityEngine;

public class FixedBouncySurface : BouncySurface
{
     
    private void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector2 normal = collision.GetContact(0).normal;
            ball.UpdateVelocity(-normal * this.bounceStrength);
        }
    }
}
