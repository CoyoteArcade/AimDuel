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

    // Position of the first target
    private Vector3 startPos;

    // Offset distance from the first target's position;
    public const float offsetX = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        numTargets = 3;
        numVisibleTargets = 2;

        // Creates target instances with Target Plane as parent
        for (int i = 0; i < numTargets; i++)
        {
            target = Instantiate(targetPrefab, this.transform) as GameObject;
            target.transform.localPosition = new Vector3(0, 0, 0);
        }
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

