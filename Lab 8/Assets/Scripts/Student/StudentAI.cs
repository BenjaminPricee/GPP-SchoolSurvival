using UnityEngine;
using UnityEngine.AI;

public class StudentAI:MonoBehaviour
{
    private STUDENT_STATES STATE;
    public NavMeshAgent navigation;

    private int group;
    private Classes classes;

    private void Start()
    {
        navigation.updateRotation = false;
        navigation.updateUpAxis = false;

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
    }
}