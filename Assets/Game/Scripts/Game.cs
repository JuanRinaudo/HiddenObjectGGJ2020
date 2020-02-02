using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{

    private enum GameState
    {
        RUNNING,
        VICTORY,
        LOSE
    }

    public static Game the;
    public Image intro;
    public Image fadeModal;
    public TextMeshProUGUI victory;
    public TextMeshProUGUI defeat;
    public GameObject endContainer;

    public AudioSource gameMusic;
    public float gameMusicMinPitch = 1;
    public float gameMusicMaxPitch = 1;

    public GameObject coinSlots;
    public Image fullCoin;
    public RectTransform coinTarget;

    public Transform sandMaskTop;
    private Vector3 maskTopInitialPosition;
    public Transform sandMaskBottom;
    private Vector3 maskBottomInitialPosition;

    private float gameLoseCounter;
    private GameState gameState;

    private int runeCount;

    public AbstractAction[] winActions;

    private const int GAME_LOSE_TIME = 90;
    private const int RUNE_WIN_COUNT = 5;
    private const float MASK_OFFSET = 0.45f;

    private void Awake()
    {
        if (the != null)
        {
            Destroy(the.gameObject);
        }

        maskTopInitialPosition = sandMaskTop.localPosition;
        maskBottomInitialPosition = sandMaskBottom.localPosition;

        runeCount = 0;
        gameLoseCounter = GAME_LOSE_TIME;

        PlayDoorStart();
        LeanTween.delayedCall(1.5f, PlayDoorSlam);

        fadeModal.gameObject.SetActive(true);
        fadeModal.color = new Color(0, 0, 0, 1);
        LeanTween.delayedCall(1.6f, FadeIn);
        intro.gameObject.SetActive(true);
        LeanTween.color(intro.rectTransform, new Color(1, 1, 1, 0), 0.5f).setDelay(1.0f);

        the = this;
    }

    private void PlayDoorStart()
    {
        Sound.the.PlaySound(Sound.the.startSound);
    }

    private void PlayDoorSlam()
    {
        Sound.the.PlaySound(Sound.the.doorSlamSound);
    }

    private void Update()
    {
        gameLoseCounter = Mathf.Clamp(gameLoseCounter - Time.deltaTime, 0, GAME_LOSE_TIME);

        float percentGameTime = (1 - gameLoseCounter / GAME_LOSE_TIME); // NOTE(Juan): Game time 0 -> 1
        sandMaskTop.localPosition = maskTopInitialPosition - new Vector3(0, percentGameTime * MASK_OFFSET, 0);
        sandMaskBottom.localPosition = maskBottomInitialPosition - new Vector3(0, -percentGameTime * MASK_OFFSET, 0);

        gameMusic.pitch = Mathf.Lerp(gameMusicMinPitch, gameMusicMaxPitch, percentGameTime);

        if(gameLoseCounter <= 0 && gameState == GameState.RUNNING)
        {
            gameState = GameState.LOSE;

            LeanTween.value(0, 1, 0.5f).setDelay(1).setOnUpdate(
                (float value) =>
                {
                    defeat.color = new Color(1, 1, 1, value);
                }
            );

            FadeOut();
        }
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
        fadeModal.color = gameState == GameState.VICTORY ? new Color(1, 1, 1, 0) : new Color(0, 0, 0, 0);
        LeanTween.color(fadeModal.rectTransform, gameState == GameState.VICTORY ? new Color(1, 1, 1, 1) : new Color(0, 0, 0, 1), 0.5f).setEase(LeanTweenType.linear).setOnComplete(EnableEndContainer);
    }

    private void EnableEndContainer()
    {
        endContainer.SetActive(true);
    }

    private void HideModal()
    {
        fadeModal.gameObject.SetActive(false);
    }

    public void RuneAdded()
    {
        if(gameState == GameState.RUNNING)
        {
            runeCount++;
            if(runeCount == RUNE_WIN_COUNT)
            {
                foreach(AbstractAction action in winActions)
                {
                    action.PlayAction();
                }

                gameState = GameState.VICTORY;

                victory.text = "VICTORY\n" + "in " + Mathf.Round(GAME_LOSE_TIME - gameLoseCounter) + "s";
                LeanTween.value(0, 1, 0.5f).setDelay(4).setOnUpdate(
                    (float value) =>
                    {
                        victory.color = new Color(1, 1, 1, value);
                    }
                );

                Sound.the.PlaySound(Sound.the.endSound);

                coinSlots.gameObject.SetActive(false);
                fullCoin.gameObject.SetActive(true);
                LeanTween.move(fullCoin.rectTransform, coinTarget.anchoredPosition, 3f).setEase(LeanTweenType.easeOutQuad);
                LeanTween.scale(fullCoin.rectTransform, new Vector3(10, 10, 1), 5f).setDelay(3).setEase(LeanTweenType.easeOutQuad);

                LeanTween.delayedCall(3, FadeOut);
                LeanTween.delayedCall(15, Application.Quit);
            }
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

}
