using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 200;

    public void DamageEnemy(int amount) {
        health -= amount;
        if (health < 0) {
            health = 0;
        }
    }
}
