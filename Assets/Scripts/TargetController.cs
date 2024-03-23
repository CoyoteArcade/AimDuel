using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;
    private GameObject target;

    private Vector3 originalPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        target = Instantiate(targetPrefab, this.transform) as GameObject;
        target.transform.localPosition = new Vector3(0, 0, 0);
    }

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


    // Update is called once per frame
    void Update()
    {
        
    }
}

