using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public EnemyAI brain;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<StudentAI>())
        {
            brain.Aggro(collision.gameObject);
            transform.localScale = new Vector3(5, 5, 1);
            collision.GetComponent<StudentAI>().Panic(brain.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<StudentAI>())
        {
            brain.Calm();
            transform.localScale = new Vector3(2, 2, 1);
        }
    }
}
