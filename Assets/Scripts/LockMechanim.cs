using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanim : MonoBehaviour
{
    public DoorMechanim[] door;
    public Key.KeyColor keyColor;

    Animator keyAnimator;
    bool playerInRange;

    private void Start()
    {
        keyAnimator = GetComponent<Animator>();
    }

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
            UseKey();
            keyAnimator.SetTrigger("Unlock");
        }
    }
    void UseKey()
    {
        switch (keyColor)
        {
            case Key.KeyColor.Gold:
                GameManager.Instance.goldenKeys--;
                break;

            case Key.KeyColor.Green:
                GameManager.Instance.greenKeys--;
                break;

            case Key.KeyColor.Red:
                GameManager.Instance.redKeys--;
                break;
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

    public void Open()
    {
        foreach (DoorMechanim d in door)
        {
            d.open = true;
        }
    }
}
