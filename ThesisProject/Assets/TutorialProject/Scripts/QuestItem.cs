using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour, F_IInteractable
{

    public string itemName;

    public void Interact()
    {
        EventController.Instance.QuestItemInteracted(itemName);

        Destroy(gameObject);
    }


}
