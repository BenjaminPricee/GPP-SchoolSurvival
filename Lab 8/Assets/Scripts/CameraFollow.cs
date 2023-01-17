using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform body;
    public Transform player;

    private void Update()
    {
        Vector3 pos = player.position;
        pos.z = -10;
        body.position = pos;
    }
}
