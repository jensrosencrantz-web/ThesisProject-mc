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
        // Beroende på vilken typ av mål det är, prenumerera på olika händelser. För interaktionsmål, vi prenumererar på en händelse som utlöses när spelaren interagerar med ett objekt.
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
        // För att uppdatera UI när målet gör framsteg, vi hittar QuestGiver och skickar ett meddelande för att uppdatera UI:t.
        QuestGiver giver = UnityEngine.Object.FindObjectOfType<QuestGiver>();

            if (giver != null)
            {
                giver.SendMessage("UpdateProgressUI");
            }

        if (currentAmount >= requiredAmount)
        {
            completed = true;
            Debug.Log("Goal Completed!");

            // När ett mål är klart, kontrollera om hela questen är klar.
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

// Define the types of goals that can exist within the game. You can expand this in the future.
public enum QuestGoalType
{
    Interact,
    Kill
}