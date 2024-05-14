using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrackButton : MonoBehaviour
{
    private DifficultySetter setter;
    private TextMeshProUGUI trackText;
    // Start is called before the first frame update
    void Start()
    {
        setter = GameObject.Find("GameController").GetComponent<DifficultySetter>();
        trackText = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(trackText.text);

        trackText.text = "Track: OFF";
    }

    // Update is called once per frame
    void Update()
    {

        if (setter.difficulty == "medium") {
            trackText.text = "Track: ON";
        } else {
            trackText.text = "Track: OFF";
        }
    }


    public void OnButtonClick() {
        setter.changetracking();
    }
}