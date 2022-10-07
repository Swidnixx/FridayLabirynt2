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
    bool paused;

    int diamonds = 0;
    int keys = 0;

    //Unity Callbacks
    private void Start()
    {
        InvokeRepeating(nameof(TimerTick), 3, 1 );
    }
    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if(paused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    //Game Flow Methods
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
    void GameOver()
    {
        CancelInvoke(nameof(TimerTick));
    }
    void Pause()
    {
        Debug.Log("Game Paused");
        paused = true;
        Time.timeScale = 0;
    }
    void Unpause()
    {
        Debug.Log("Game Resumed");
        paused = false;
        Time.timeScale = 1;
    }

    //Pickup Interactions
    public void AddDiamond()
    {
        diamonds++;
    }
    public void AddKey()
    {
        keys++;
    }
    public void FreezeTime(int time)
    {
        CancelInvoke(nameof(TimerTick));
        InvokeRepeating(nameof(TimerTick), time, 1);
    }
}
