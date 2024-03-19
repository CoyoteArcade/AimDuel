using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    //respawn at the same spot
    private Vector3 originalPosition;

    // If this target is hit, react to it
    public void ReactToHit() {
        StartCoroutine(Die());
    }

    // Death animation as a couroutine
    public IEnumerator Die() {
        Respawn();
        yield return new WaitForSeconds(0f);
    }
    // modify the respawn function to respawn at a differnt location within the play area
    private void Respawn(){

        // respawn at random location
        float x = Random.Range(-18, 18);
        float y = Random.Range(4, 18);
        Vector3 newPos = new Vector3(0, y, x);
        // log the new position
        Debug.Log("New Position: " + newPos);
        transform.position = newPos;

    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        Debug.Log("Original Position: " + originalPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

