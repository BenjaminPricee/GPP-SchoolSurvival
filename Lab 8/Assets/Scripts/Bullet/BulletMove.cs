using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Rigidbody2D body;
    public int speed;

    private void Update()
    {
        body.velocity = transform.right * -speed;
    }
}
