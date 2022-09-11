using UnityEngine;

public class StartFocus : MonoBehaviour
{
    public Rigidbody2D topBar;
    public Rigidbody2D bottomBar;
    public Rigidbody2D leftBar;
    public Rigidbody2D rightBar;

    public Ball ball;

    public float speed = 0.01f;

    private bool roundIsUp;

    private void Awake() {
        topBar.transform.localScale = Vector3.zero;
        bottomBar.transform.localScale = Vector3.zero;
        leftBar.transform.localScale = Vector3.zero;
        rightBar.transform.localScale = Vector3.zero;
    }

    public void DisplayFocus()
    {
        roundIsUp = false;

        topBar.position = new Vector3(0, 1.9f, 0);
        bottomBar.position = new Vector3(0, -1.9f, 0);
        leftBar.position = new Vector3(-1.9f, 0, 0);
        rightBar.position = new Vector3(1.9f, 0, 0);

        UpdateScale();

        topBar.AddForce(Vector2.down * this.speed);
        bottomBar.AddForce(Vector2.up * this.speed);
        leftBar.AddForce(Vector2.right * this.speed);
        rightBar.AddForce(Vector2.left * this.speed);
    }

    private void Update()
    {   
        if(!roundIsUp) 
        {
            UpdateScale();

            if(topBar.position.y <= 0.2f) // We only test for the top bar
            { 
                roundIsUp = true;
                topBar.velocity = Vector2.zero;
                bottomBar.velocity = Vector2.zero;
                leftBar.velocity = Vector2.zero;
                rightBar.velocity = Vector2.zero;

                topBar.transform.localScale = Vector3.zero;
                bottomBar.transform.localScale = Vector3.zero;
                leftBar.transform.localScale = Vector3.zero;
                rightBar.transform.localScale = Vector3.zero;

                ball.Launch();
            }
        }
    }

    private void UpdateScale()
    {
        float distanceToCenter = topBar.position.y;
        topBar.transform.localScale = new Vector3(distanceToCenter*2 + 0.2f, 0.2f, 0);
        bottomBar.transform.localScale = new Vector3(distanceToCenter*2 + 0.2f, 0.2f, 0);
        leftBar.transform.localScale = new Vector3(0.2f, distanceToCenter*2, 0);
        rightBar.transform.localScale = new Vector3(0.2f, distanceToCenter*2, 0);
    }
}
