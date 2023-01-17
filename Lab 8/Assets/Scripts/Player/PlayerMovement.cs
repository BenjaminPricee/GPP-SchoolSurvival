using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;

    public float speed = 0.1f;
    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * speed * Time.deltaTime);
    }
}
