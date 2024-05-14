using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicPortrait : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] Sprite portrait;
    [SerializeField] Sprite portraitHurt;
    [SerializeField] Sprite portraitDead;
    bool isHurt;
    bool isDead;

    Image portraitImage;

    void Start() {
        portraitImage = GetComponent<Image>();
    }

    void Update()
    {
        isHurt = playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Hurt");
        isDead = playerAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Dead");

        ChangePortrait();
    }

    void ChangePortrait() {
        if (isDead) {
            portraitImage.sprite = portraitDead;
        } else if (isHurt) {
            portraitImage.sprite = portraitHurt;
        } else {
            portraitImage.sprite = portrait;
        }
    }
}
