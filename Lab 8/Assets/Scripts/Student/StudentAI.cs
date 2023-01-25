using UnityEngine;
using UnityEngine.AI;

public class StudentAI:MonoBehaviour
{
    private STUDENT_STATES STATE;
    public NavMeshAgent navigation;
    public Rigidbody2D body;

    private Vector2 oldPos;

    private int group;
    private Classes classes;

    private GameObject enemy;

    private void Start()
    {
        navigation.updateRotation = false;
        navigation.updateUpAxis = false;
        oldPos = body.position;

        group = Random.Range(0, 2);
        classes = FindObjectOfType<Classes>();

        STATE = STUDENT_STATES.GO_CLASS;
    }

    private void Update()
    {
        if(STATE==STUDENT_STATES.GO_CLASS)
        {
            navigation.SetDestination(classes.Current(group).position);

        }
        else if(STATE==STUDENT_STATES.RUN)
        {
            Vector2 run = transform.position - enemy.transform.position;
            if(run.magnitude > 3)
            {
                enemy = null;
                STATE = STUDENT_STATES.GO_CLASS;
            }
            else
            {
                navigation.SetDestination(body.position + run.normalized);
            }
        }

        Vector2 dir = oldPos - body.position;

        if(dir != Vector2.zero)
        {
            dir.Normalize();
            body.rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            oldPos = body.position;
        }
    }

    public void Panic(GameObject t_enemy)
    {
        STATE = STUDENT_STATES.RUN;
        enemy = t_enemy;
    }

    private void OnDestroy()
    {
        FindObjectOfType<Score>().ScoreDown();
    }
}