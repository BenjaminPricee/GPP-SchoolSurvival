using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    private void OnDestroy()
    {
        SceneManager.LoadScene(0);
    }
}
