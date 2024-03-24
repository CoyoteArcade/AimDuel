using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;
    [SerializeField] int numTargets;
    [SerializeField] int numVisibleTargets;
    private GameObject target;

    private Vector3 originalPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        numTargets = 3;
        numVisibleTargets = 2;

        // Creates target instance with Target Plane as its parent
        target = Instantiate(targetPrefab, this.transform) as GameObject;
        target.transform.localPosition = new Vector3(0, 0, 0);
    }

    // If this target is hit, react to it
    public void ReactToHit() {
        StartCoroutine(Die());
    }

    public IEnumerator Die() {
        Respawn();
        yield return new WaitForSeconds(0f);
    }
    // modify the respawn function to respawn at a differnt location within the play area
    private void Respawn() {

    }


    // Update is called once per frame
    void Update()
    {
        // Keep visible targets less than total amount of targets
        if (numVisibleTargets >= numTargets) {
            numVisibleTargets = numTargets - 1;
        }
    }
}

