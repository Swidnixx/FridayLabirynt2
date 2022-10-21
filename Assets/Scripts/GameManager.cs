using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Key;

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
    int redKeys = 0;
    int greenKeys = 0;
    int goldenKeys = 0;

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
        //Debug.Log("Time: " + time);

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
    public void AddKey(Key.KeyColor keyColor)
    {
        switch(keyColor)
        {
            case KeyColor.Red:
                redKeys++;
                break;

            case KeyColor.Green:
                greenKeys++;
                break; ;

            case KeyColor.Gold:
                goldenKeys++;
                break;
        }
    }
    public void FreezeTime(int time)
    {
        CancelInvoke(nameof(TimerTick));
        InvokeRepeating(nameof(TimerTick), time, 1);
    }
    public void AddTime(int time)
    {
        this.time += time;
    }
}
