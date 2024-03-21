using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;

public class AccuracyUpdater : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = $"Accuracy: {ScoreManager.Instance.accuracy}%";
    }

    void Update()
    {
        textMeshPro.text = $"Accuracy: {ScoreManager.Instance.accuracy}%";
    }
}
