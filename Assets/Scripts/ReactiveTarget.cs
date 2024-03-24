using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private TargetController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<TargetController>();
    }

    // If this target is hit, react to it
    public void ReactToHit() {
        // Get target index from its instance name 
        int randomTarget = int.Parse(this.name.Substring(7));
        controller.updateVisible(randomTarget);

        // Target disappears when shot
        this.transform.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
