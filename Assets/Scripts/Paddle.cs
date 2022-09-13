using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 5f;
    public new Rigidbody2D rigidbody { get; private set; }
    public float bounceStrength = 1f;
    public float directionModifierStrength = 1f;

    public AudioSource bounceSoundEffect;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            bounceSoundEffect.Play();

            Vector2 normal = collision.GetContact(0).normal;
            Vector3 contactPoint = collision.GetContact(0).point;
            float modifier = contactPoint.y - rigidbody.position.y;

            // Direction modifier
            Vector2 directionModifier = (Vector2.up * modifier * directionModifierStrength);
            directionModifier.Normalize();
            Vector2 direction = -normal + directionModifier;
            ball.AddForce(direction * this.bounceStrength);
        }
    }
}
