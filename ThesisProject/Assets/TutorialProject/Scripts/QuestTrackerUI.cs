using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestTrackerUI : MonoBehaviour
{

    public TextMeshProUGUI questText;

    PlayerQuests playerQuests;


    // Start is called before the first frame update
    void Start()
    {
        playerQuests =  FindAnyObjectByType<PlayerQuests>();
    }
        

    // Update is called once per frame
    void Update()
    {
        if( playerQuests.activeQuests.Count == 0)
        {
            questText.text = "";
            return;
        }

        Quest quest = playerQuests.activeQuests[0]; // För enkelhetens skull, vi visar bara den första questen
        Goal goal = quest.goals[0]; // För enkelhetens skull, vi visar bara det första målet
        questText.text = quest.title + "\n" +  "Progress: " + goal.currentAmount + "/" + goal.requiredAmount;
    }
}
