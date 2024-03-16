using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    // If this target is hit, react to it
    public void ReactToHit() {
        StartCoroutine(Die());
    }

    // Death animation as a couroutine
    public IEnumerator Die() {
        // 'this' refers to the script component ReactiveTarget
        // Target falls over to the side
        this.transform.Rotate(-75, 0, 0);

        // Then Wait
        yield return new WaitForSeconds(1.5f);

        // Remember: this.gameObject refers to the gameObject attached to this script: ReactiveTarget

        // Despawns itself after falling
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

