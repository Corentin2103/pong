using UnityEngine;

public class Ball : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    private Renderer _renderer;
    private TrailRenderer _trailRenderer;

    public Material DefaultMaterial;
    public Material PlayerMaterial;
    public Material ComputerMaterial;
    public Color PlayerTrailColor;
    public Color ComputerTrailColor;

    public float speed = 200.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<Renderer>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    public void Launch()
    {
        this.SetRenderer(true);
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction*this.speed);
    }

    public void AddForce(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }

    public void UpdateVelocity(Vector2 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    public void Reset()
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
        _renderer.material = DefaultMaterial;
        _trailRenderer.material.color = Color.white;
        
    }

    public void SwitchToPlayerMaterial()
    {
        _renderer.material = PlayerMaterial;
        _trailRenderer.material.color = PlayerTrailColor;
    }

    public void SwitchToComputerMaterial()
    {
        _renderer.material = ComputerMaterial;
        _trailRenderer.material.color = ComputerTrailColor;
    }

    public void SetRenderer(bool boolean)
    {
        _trailRenderer.enabled = boolean;
    }
}
