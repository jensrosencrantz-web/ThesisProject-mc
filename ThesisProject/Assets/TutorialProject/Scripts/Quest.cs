using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Quest 
{

    public string title;
    public string description;

    public int reward;
    public bool isActive;
    public List <Goal> goals;

    public void Init()
    {
        isActive = true;

        foreach (Goal goal in goals)
        {
            goal.Init();
        }
    }

    public void CheckCompletion()
    {
        foreach (Goal goal in goals)
        {
            if (!goal.completed)
            {
                return;
            }

        }
        Complete();
    }

    void Complete()
    {
        isActive = false;
        Debug.Log("Quest Completed! Reward!");
    }



}
