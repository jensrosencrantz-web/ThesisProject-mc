using UnityEngine;

[System.Serializable]
public class Goal
{
    public QuestGoalType goalType;

    public string objectiveName;
    public int currentAmount;
    public int requiredAmount;
    public bool completed;

    public void Init()
    {
        switch (goalType)
        {
            case QuestGoalType.Interact:
                EventController.Instance.OnQuestItemInteracted += ObjectInteracted;
                break;

            case QuestGoalType.Kill:
                break;
        }
    }

    void Evaluate()
    {
        if (currentAmount >= requiredAmount)
        {
            completed = true;
            Debug.Log("Goal Completed!");

            PlayerQuests playerQuests = UnityEngine.Object.FindObjectOfType<PlayerQuests>();
            if (playerQuests != null)
            {
                playerQuests.CheckQuests();
            }

        }
    }

    public void ObjectInteracted(string objectName)
    {
        if (objectName == objectiveName)
        {
            currentAmount++;
            Evaluate();
        }
    }
}

public enum QuestGoalType
{
    Interact,
    Kill
}