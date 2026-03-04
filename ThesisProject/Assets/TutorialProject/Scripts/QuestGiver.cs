using UnityEngine;
using TMPro; // om du använder TextMeshPro
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestGiver : MonoBehaviour, F_IInteractable
{
    public List <Quest> quests = new List<Quest>(); // Referens till questen som ges av denna NPC
    int currentQuestIndex = 0; // Håller reda på vilken quest som är aktuell    
    public GameObject questUI; // UI-panelen som visar questinformationen
    public TextMeshProUGUI titleText; // Textkomponenten för questtiteln
    public TextMeshProUGUI descriptionText; // Textkomponenten för questbeskrivningen
    public Button acceptButton; // Knappen för att acceptera questen

    public TextMeshProUGUI progressText; // Textkomponenten för att visa questens progress  

    private void Start()
    {
        // Se till att UI är inaktiverat i början
        questUI.SetActive(false);

        // Lägg till en lyssnare på accept-knappen
        acceptButton.onClick.AddListener(AcceptQuest);
    }

    public void Interact()
    {
        // När spelaren interagerar med NPC:n, visa questinformationen
        if(currentQuestIndex >= quests.Count)
        {
            Debug.Log("No more quests to give!");
            return;
        }
        Quest quest = quests[currentQuestIndex];
        // Visa questinformationen när spelaren interagerar med NPC:n
        titleText.text = quest.title;
        descriptionText.text = quest.description;

        UpdateProgressUI();

        questUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None; // Lås upp musen
        Cursor.visible = true; // Gör musen synlig
    }

    void UpdateProgressUI()
    {
        if (currentQuestIndex >= quests.Count)
            return;

            Quest quest = quests[currentQuestIndex];

            if (quest == null) return;
            if (quest.goals.Count == 0) return;

            Goal goal = quest.goals[0];

            progressText.text = "Progress: " + goal.currentAmount + " / " + goal.requiredAmount;
    }

    

   private void AcceptQuest()
    {
        if (currentQuestIndex >= quests.Count)
        return;

        Quest quest = quests[currentQuestIndex];

        Debug.Log("Accept Quest Button Clicked!");

        if (quest.isActive)
        return;

        quest.Init();
        FindObjectOfType<PlayerQuests>().activeQuests.Add(quest);

        currentQuestIndex++;

        questUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }   
}
