using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanim : MonoBehaviour
{
    public Transform door;
    public Transform closedPos;
    public Transform openPos;
    public float openSpeed = 1;
    public bool open;

    private void Update()
    {
        if(open && !Mathf.Approximately(Vector3.Distance(door.position, openPos.position),0))
        {
            door.position = Vector3.MoveTowards(door.position, openPos.position, Time.deltaTime * openSpeed);
        }

        if(!open && Vector3.Distance(door.position, closedPos.position) > Mathf.Epsilon)
        {
            door.position = Vector3.MoveTowards(door.position, closedPos.position, Time.deltaTime * openSpeed);
        }
    }
}
