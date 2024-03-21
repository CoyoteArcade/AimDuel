using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public double accuracy;
    public static ScoreManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void UpdateScore(int newScore) {
        score = newScore;
    }

    public void UpdateAccuracy(double newAccuracy) {
        accuracy = newAccuracy;
    }

}
