using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private ENEMY_STATES STATE;
    private Rigidbody2D body;

    public NavMeshAgent navigation;
    public Transform[] patrol;
    private int currentPatrol;

    private GameObject target;

    private void Start()
    {
        navigation.updateRotation = false;
        navigation.updateUpAxis = false;

        body= GetComponent<Rigidbody2D>();

        STATE = ENEMY_STATES.PATROL;
        currentPatrol = Random.Range(0, 4);
        navigation.SetDestination(patrol[currentPatrol].position);
    }

    private void Update()
    {
        if(STATE == ENEMY_STATES.PATROL)
        {
            if(Vector3.Distance(transform.position, patrol[currentPatrol].position) < 1)
            {
                UpdatePatrol();
                navigation.SetDestination(patrol[currentPatrol].position);
            }

            body.rotation = Mathf.Atan2(patrol[currentPatrol].position.y, patrol[currentPatrol].position.x) * Mathf.Rad2Deg;
            body.rotation -= 135;
        }
        else if (STATE == ENEMY_STATES.ATTACK)
        {
            Vector2 dir = transform.position - target.transform.position;
            dir.Normalize();
            body.rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            navigation.SetDestination(target.transform.position);
        }
    }

    private void UpdatePatrol()
    {
        currentPatrol++;
        currentPatrol %= 4;
    }

    public void Aggro(GameObject t_target)
    {
        STATE = ENEMY_STATES.ATTACK;
        target = t_target;
    }

    public void Calm()
    {
        STATE = ENEMY_STATES.PATROL;
        target = null;
        navigation.SetDestination(patrol[currentPatrol].position);
    }
}
