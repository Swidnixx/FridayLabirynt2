using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // SINGLETON
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple GMs in the scene");
        }
    }

    // FUNCTIONALITY
    [SerializeField] int time = 60;

    private void Start()
    {
        InvokeRepeating(nameof(TimerTick), 3, 1 );
    }

    void TimerTick()
    {
        time--;
        Debug.Log("Time: " + time);

        if(time <= 0)
        {
            time = 0;
            GameOver();
        }
    }

    private void GameOver()
    {
        CancelInvoke(nameof(TimerTick));
    }
}
