using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = $"Score: {ScoreManager.Instance.score}";
    }

    void Update()
    {
        textMeshPro.text = $"Score: {ScoreManager.Instance.score}";
    }
}