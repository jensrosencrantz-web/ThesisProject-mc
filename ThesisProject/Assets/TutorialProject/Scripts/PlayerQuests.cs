using System.Collections.Generic;
using UnityEngine;

public class PlayerQuests : MonoBehaviour
{
    public List<Quest> activeQuests = new List<Quest>();

    public void CheckQuests()
    {
        foreach (Quest quest in activeQuests)
        {
            if (!quest.isActive)
                continue;

            quest.CheckCompletion();
        }
    }
}