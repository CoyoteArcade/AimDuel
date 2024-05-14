using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text dreamCoins;
    [SerializeField] PlayerInventory playerInventory;

    void Update()
    {
        dreamCoins.text = $"X {playerInventory.numOfCoins}";
    }
}
