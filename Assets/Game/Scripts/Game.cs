using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{

    public static Game the;
    public Image fadeModal;
    public TextMeshProUGUI victory;
    public TextMeshProUGUI defeat;

    private int runeCount;

    private const int RUNE_WIN_COUNT = 5;

    private void Awake()
    {
        if (the != null)
        {
            Destroy(the.gameObject);
        }

        runeCount = 0;

        FadeIn();

        the = this;
    }

    public void FadeIn()
    {
        fadeModal.gameObject.SetActive(true);
        LeanTween.cancel(fadeModal.rectTransform);
        fadeModal.color = new Color(0, 0, 0, 1);
        LeanTween.color(fadeModal.rectTransform, new Color(0, 0, 0, 0), 0.5f).setEase(LeanTweenType.linear).setOnComplete(HideModal);
    }

    public void FadeOut()
    {
        fadeModal.gameObject.SetActive(true);
        LeanTween.cancel(fadeModal.rectTransform);
        fadeModal.color = new Color(0, 0, 0, 0);
        LeanTween.color(fadeModal.rectTransform, new Color(0, 0, 0, 1), 0.5f).setEase(LeanTweenType.linear);
    }

    private void HideModal()
    {
        fadeModal.gameObject.SetActive(false);
    }

    public void RuneAdded()
    {
        runeCount++;
        if(runeCount == RUNE_WIN_COUNT)
        {
            LeanTween.value(0, 1, 0.5f).setDelay(4).setOnUpdate(
                (float value) =>
                {
                    victory.color = new Color(1, 1, 1, value);
                }
            );

            LeanTween.delayedCall(3, FadeOut);
        }
    }

}
