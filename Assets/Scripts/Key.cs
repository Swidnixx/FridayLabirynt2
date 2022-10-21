using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Pickup
{
    public enum KeyColor
    {
        Red,
        Green,
        Gold
    }

    public KeyColor keyColor;

    public override void Pick()
    {
        Debug.Log("Podniesiono klucz");
        GameManager.Instance.AddKey(keyColor);
        base.Pick();
    }
}
