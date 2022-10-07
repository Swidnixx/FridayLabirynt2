using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Pickup
{
    public int freezeTime = 10;

    public override void Pick()
    {
        Debug.Log("Podniesiono Freeze");
        GameManager.Instance.FreezeTime(freezeTime);
        base.Pick();
    }
}
