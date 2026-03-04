using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int gold;

    public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log("Gold:" + gold);
    }
}
