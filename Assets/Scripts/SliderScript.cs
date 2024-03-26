using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    // Start is called before the first frame update
    void Start()
    {
        if (SensController.Instance != null) {
            slider.value = SensController.Instance.sensitivity;
        } else {
            slider.value = 0.75f;
        }
        
        sliderText.text = slider.value.ToString("0.00");
        
        slider.onValueChanged.AddListener((value) =>
        {
            if (SensController.Instance != null) {
                SensController.Instance.sensitivity = slider.value;
            }
            sliderText.text = value.ToString("0.00");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
