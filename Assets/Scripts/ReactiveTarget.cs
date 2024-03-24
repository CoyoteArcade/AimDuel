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
        this.transform.gameObject.SetActive(false);
        Debug.Log($"{this.name} has been shot");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
