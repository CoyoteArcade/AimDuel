using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // If this target is hit, react to it
    public void ReactToHit() {
        Debug.Log("I've been hit!");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
