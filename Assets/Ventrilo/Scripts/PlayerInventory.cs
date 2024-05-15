using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int numOfCoins;
    [SerializeField] AudioSource coinSound;

    void Start() {
        numOfCoins = 0;
    }

    public void addCoins(int amount) {
        coinSound.Play();
        numOfCoins += amount;
    }
}
