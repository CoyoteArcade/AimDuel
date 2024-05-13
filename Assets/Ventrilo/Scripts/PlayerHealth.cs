using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;

    void Update() {
    }

    public void HealPlayer(int amount) {
        health += amount;
        if (health > 100) {
            health = 100;
        }
    }

    public void DamagePlayer(int amount) {
        health -= amount;
        if (health < 0) {
            health = 0;
        }
    }
}
