using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
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
    // Array with visible target instance indices
    public int[] visibleTargets;
  

    // Distance from the first target's position (TOP LEFT CORNER)
    public float offset = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        targetDimensions = 4;
        numVisibleTargets = 3;
        visibleTargets = new int[numVisibleTargets];

        // Store list of target instances
        var targetList = new List<GameObject>();

        // Starting (local) position of first target
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

                // Rename targets and add to target list
                target.name = $"Target {targetList.Count}";
                targetList.Add(target);

                // Set target to be invisible
                target.SetActive(false);
            }
        }

        targets = targetList.ToArray();

        // Set random targets to be visible
        for (int i = 0; i < visibleTargets.Length; i++)
        {
            // Pick random target that isn't already visible
            int randomTarget;
            do
            {
                randomTarget = Random.Range(0, targets.Length);
            } while (System.Array.Exists(visibleTargets, num => num == randomTarget));

            targets[randomTarget].SetActive(true);
            visibleTargets[i] = randomTarget;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Keep visible targets less than total amount of targets
        if (numVisibleTargets >= targets.Length) {
            numVisibleTargets = targets.Length - 1;
        }
    }
}

