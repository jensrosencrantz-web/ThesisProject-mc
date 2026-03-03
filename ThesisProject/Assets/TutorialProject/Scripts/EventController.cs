using System;
using UnityEngine;

public class EventController : MonoBehaviour
{
    // Singleton instance
    public static EventController Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    

    // Action som skickar med namnet på objektet
    public Action<string> OnQuestItemInteracted;

    // Metod för att trigga eventet
    public void QuestItemInteracted(string itemName)
    {
        OnQuestItemInteracted?.Invoke(itemName);
    }
}
