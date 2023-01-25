using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public NavMeshAgent navigator;
    public Rigidbody2D body;
    public Animator anim;

    public float speed = 0.1f;
    private Vector2 movement;

    private void Start()
    {
        navigator.updateRotation = false;
        navigator.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        navigator.SetDestination(body.position + movement);

        if(movement != Vector2.zero)
        {
            anim.SetBool("isWalking", true);

            movement.x *= -1;
            movement.y *= -1;
            body.rotation = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
