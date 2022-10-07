using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Pickup
{
    public override void Pick()
    {
        Debug.Log("Podniesiono klucz");
        GameManager.Instance.AddKey();
        base.Pick();
    }
}
