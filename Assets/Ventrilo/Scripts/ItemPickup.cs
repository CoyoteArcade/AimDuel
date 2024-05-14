using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] PlayerInventory playerInventory;

    void OnTriggerEnter2D(Collider2D other) {
        // Coin Pickup
        if (this.gameObject.tag == "Coin") {
            if (other.tag == "Player") {
                playerInventory.addCoins(1);
                Destroy(this.gameObject);
            }
        }
    }
}
