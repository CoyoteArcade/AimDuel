using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;
    // Change to set N x N dimensions for targets displayed
    [SerializeField] int targetDimensions;
    [SerializeField] int numVisibleTargets;

    // Single target instance
    private GameObject target;
    // Array with all target instances
    private GameObject[] targets;
    private int numOfTargets;

    // Distance from the first target's position;
    public float offset = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        targetDimensions = 4;
        numOfTargets = targetDimensions * targetDimensions;
        numVisibleTargets = 2;
        targets = new List<GameObject>().ToArray();
        Debug.Log(targets.Length);

        Vector3 startPos = new Vector3(0, 0, 0);

        // Creates target instances with Target Plane as parent
        for (int i = 0; i < targetDimensions; i++)
        {
            for (int j = 0; j < targetDimensions; j++)
            {
                target = Instantiate(targetPrefab, this.transform) as GameObject;
                if (i == 0 && j == 0) {
                    target.transform.localPosition = startPos;
                } else {
                    target.transform.localPosition = new Vector3(offset * i + startPos.x, -(offset * j + startPos.y), 0);
                }
                target.name = $"Target {targets.Length}";
            }
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
        if (numVisibleTargets >= numOfTargets) {
            numVisibleTargets = numOfTargets - 1;
        }
    }
}

