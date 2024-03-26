using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensController : MonoBehaviour
{
    public float sensitivity;
    public static SensController Instance;

    // Start is called before the first frame update
    void Start()
    {
        sensitivity = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }
}
