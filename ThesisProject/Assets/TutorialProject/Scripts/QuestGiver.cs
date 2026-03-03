using UnityEngine;
using TMPro; // om du använder TextMeshPro
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour, F_IInteractable
{
    public Quest quest; // Referens till questen som ges av denna NPC

    public GameObject questUI; // UI-panelen som visar questinformationen
    public TextMeshProUGUI titleText; // Textkomponenten för questtiteln
    public TextMeshProUGUI descriptionText; // Textkomponenten för questbeskrivningen
    public Button acceptButton; // Knappen för att acceptera questen

    private void Start()
    {

        
        // Se till att UI är inaktiverat i början
        questUI.SetActive(false);

        // Lägg till en lyssnare på accept-knappen
        acceptButton.onClick.AddListener(AcceptQuest);
    }

    public void Interact()
    {
        Debug.Log("Quest Board Interacted!");   
        // Visa questinformationen när spelaren interagerar med NPC:n
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        questUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None; // Lås upp musen
        Cursor.visible = true; // Gör musen synlig
    }

    private void AcceptQuest()
    {
        Debug.Log("Accept Quest Button Clicked!");
        if(quest.isActive)
        return;

        quest.Init();          // Initiera questen och stäng UI:t

        FindObjectOfType<PlayerQuests>().activeQuests.Add(quest);

        questUI.SetActive(false);
        Debug.Log("Quest accepted: " + quest.title);

        Cursor.lockState = CursorLockMode.Locked; // Lås musen
        Cursor.visible = false; // Gör musen osynlig
    }

}
