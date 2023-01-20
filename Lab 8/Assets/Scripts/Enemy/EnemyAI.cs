using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private ENEMY_STATES STATE;

    public NavMeshAgent navigation;

    //Transform[] Patr

    private void Start()
    {
        navigation.updateRotation = false;
        navigation.updateUpAxis = false;

        STATE = ENEMY_STATES.PATROL;
    }

    private void Update()
    {
        if(STATE == ENEMY_STATES.PATROL)
        {

        }
        else if (STATE == ENEMY_STATES.ATTACK)
        {

        }
    }
}
