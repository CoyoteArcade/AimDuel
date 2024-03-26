using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DifficultySetter : MonoBehaviour
{
    public string difficulty;
    public static DifficultySetter Instance;
    [SerializeField] private TextMeshProUGUI difficultyText;
    // Start is called before the first frame update
    void Start()
    {
        difficulty = "easy";
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

    public void changeDifficulty() {
        if (difficulty == "easy") {
            difficulty = "hard";
            Debug.Log("Changed");
        } else {
            difficulty = "easy";
        }
    }
}
