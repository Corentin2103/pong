using UnityEngine;

public class MenuBall : Ball
{
    private void Start() {
        _rigidbody.position = new Vector3(4, 0, 0);
        this.Launch();
    }

    public void Launch()
    {
        Vector2 direction = Vector2.up;
        _rigidbody.AddForce(direction*this.speed);
    }
}
