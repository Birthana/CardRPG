using System;
using UnityEngine;

[RequireComponent(typeof(BasicUI))]
public class TimeManager : MonoBehaviour
{
    public Action<int> OnTimeChange;
    [SerializeField] private int maxTime;
    private int currentTime;
    
    void Start()
    {
        OnTimeChange += GetComponent<BasicUI>().Display;
        var character = Player.FindEnergy();
        maxTime = character.GetTime();
        currentTime = maxTime;
        OnTimeChange?.Invoke(currentTime);
    }

    public void ReduceTime(int timeUsed)
    {
        currentTime -= timeUsed;
        OnTimeChange?.Invoke(currentTime);
    }
}
