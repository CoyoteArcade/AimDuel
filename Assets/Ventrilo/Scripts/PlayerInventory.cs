using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int numOfCoins;
    AudioSource coinSound;

    void Start() {
        numOfCoins = 0;
        coinSound = GetComponent<AudioSource>();
    }

    public void addCoins(int amount) {
        coinSound.Play();
        numOfCoins += amount;
    }
}
