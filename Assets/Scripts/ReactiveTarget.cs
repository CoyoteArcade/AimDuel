using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    //respawn at the same spot
    private Vector3 originalPosition;

    //respawns after time interval
    public float respawnDelay = 1f;

    // If this target is hit, react to it
    public void ReactToHit() {
        StartCoroutine(Die());
    }

    // Death animation as a couroutine
    public IEnumerator Die() {
        // some animation here using 'this' keyword

        // Then Wait
        yield return new WaitForSeconds(0f);

        // Remember: this.gameObject refers to the gameObject attached to this script: ReactiveTarget

        // Despawns itself after falling
        

        //wait for delay
        yield return new WaitForSeconds(respawnDelay);

        //target respawn
        Respawn();

        Destroy(this.gameObject);
    }

    private void Respawn(){
        //Instantiate target
        GameObject newTarget = Instantiate(this.gameObject, originalPosition, Quaternion.identity);
        //makes target active
        newTarget.SetActive(true);
    
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

