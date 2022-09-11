using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Renderer _renderer;

    public Material DefaultMaterial;
    public Material PlayerMaterial;
    public Material ComputerMaterial;

    public float speed = 200.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<Renderer>();
    }

    public void Launch()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction*this.speed);
    }

    public void AddForce(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }

    public void Reset() {
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
        _renderer.material = DefaultMaterial;
    }

    public void SwitchToPlayerMaterial()
    {
        _renderer.material = PlayerMaterial;
    }

    public void SwitchToComputerMaterial()
    {
        _renderer.material = ComputerMaterial;
    }
}
