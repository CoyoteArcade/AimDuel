using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShrinkButton : MonoBehaviour
{
    private DifficultySetter setter;
    private TextMeshProUGUI shrinkText;
    // Start is called before the first frame update
    void Start()
    {
        setter = GameObject.Find("GameController").GetComponent<DifficultySetter>();
        shrinkText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(shrinkText.text);

        shrinkText.text = "Shrink: OFF";
    }

    // Update is called once per frame
    void Update()
    {

        if (setter.difficulty == "easy") {
            shrinkText.text = "Shrink: OFF";
        } else {
            shrinkText.text = "Shrink: ON";
        }
    }
    

    public void OnButtonClick() {
        setter.changeDifficulty();
    }
}
