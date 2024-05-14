using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int numOfCoins;

    void Start() {
        numOfCoins = 0;
    }

    public void addCoins(int amount) {
        numOfCoins += amount;
    }
}
