using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingTarget : MonoBehaviour
{
    private TargetController controller;
    private RayShooter rayShooter;
    private Vector3 originalSize;
    public float shrinkRate = 0.5f;
    public float maxShrinkSize = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<TargetController>();
        rayShooter = GameObject.Find("Player/Main Camera").GetComponent<RayShooter>();
        originalSize = transform.localScale;
    }

    // If this target is hit, react to it
    public void ReactToHit() {
        // Get target index from its instance name 
        int randomTarget = int.Parse(this.name.Substring(7));
        controller.updateVisible(randomTarget);

        // Target disappears when shot
        this.transform.gameObject.SetActive(false);
        this.transform.localScale = originalSize;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= maxShrinkSize) {
            int randomTarget = int.Parse(this.name.Substring(7));
            rayShooter.addTargetFaded();
            controller.updateVisible(randomTarget);
            this.transform.gameObject.SetActive(false);
            this.transform.localScale = originalSize;
        } else {
            transform.localScale -= new Vector3(shrinkRate, shrinkRate, shrinkRate) * Time.deltaTime;
        }
    }
}