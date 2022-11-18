using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanim : MonoBehaviour
{
    public DoorMechanim[] door;
    public Key.KeyColor keyColor;

    Animator keyAnimator;
    bool playerInRange;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player out of range");
            playerInRange = false;
        }
    }

    private void Update()
    {
        bool playerWantsToOpen = Input.GetKeyDown(KeyCode.E);
        bool playerHasProperKey = CheckKey();
        if(playerWantsToOpen && playerInRange && playerHasProperKey)
        {
            OpenClose(true);
        }
    }

    bool CheckKey()
    {
        switch(keyColor)
        {
            case Key.KeyColor.Gold:
                return GameManager.Instance.goldenKeys > 0;

            case Key.KeyColor.Green:
                return GameManager.Instance.greenKeys > 0;

            case Key.KeyColor.Red:
                return GameManager.Instance.redKeys > 0;
        }
        return false;
    }

    void OpenClose(bool open)
    {
        foreach (DoorMechanim d in door)
        {
            d.open = open;
        }
    }
}
