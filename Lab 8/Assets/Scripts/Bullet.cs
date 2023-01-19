using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
