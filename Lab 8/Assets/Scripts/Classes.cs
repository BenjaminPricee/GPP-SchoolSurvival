using System.Collections;
using UnityEngine;

public class Classes : MonoBehaviour
{
    public Transform[] classes;
    private int groupA = 0;
    private int groupB = 1;

    private void Start()
    {
        StartCoroutine(ClassTimeA());
        StartCoroutine(ClassTimeB());
    }

    private IEnumerator ClassTimeA()
    {
        groupA = (groupA + 1) % 4;
        Debug.Log("A = " + groupA);

        yield return new WaitForSeconds(15);

        StartCoroutine(ClassTimeA());
    }

    private IEnumerator ClassTimeB()
    {
        groupB = (groupB + 3) % 4;
        Debug.Log("B = " + groupB);

        yield return new WaitForSeconds(20);

        StartCoroutine(ClassTimeB());
    }

    public Transform Current(int t_group)
    {
        if(t_group == 0)
            return classes[groupA];
        else
            return classes[groupB];
    }
}
