using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Pickup
{
    public override void Pick()
    {
        Debug.Log("Podniesiono diament");
        GameManager.Instance.AddDiamond();
        base.Pick();
    }
}
