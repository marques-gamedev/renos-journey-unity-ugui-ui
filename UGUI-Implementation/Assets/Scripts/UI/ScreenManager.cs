using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum eScreenTransitionType { None, Canvas_Fade, Color_Fade }

public enum eScreenIDs { Main_Menu = 0, Options = 1, Game = 2 }

[System.Serializable]
public struct ScreenDefinition
{
    public GameObject screenGo;
    public ScreenController screenController;
    public eScreenTransitionType screenTransitionType;
    public Color screenTransitionColor;
    public float screenTransitionDuration;
}

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private Image colorFadeImage;
    [SerializeField] private ScreenDefinition[] screenDefinitions;

    private Tween fadeTween;
    private Coroutine changeScreenCoroutine;

    private int currentScreenID;
    private int previousScreenID;

    public void Initialize()
    {
        previousScreenID = -1;
        currentScreenID = 0;
        screenDefinitions[currentScreenID].screenController.CanvasGroup.alpha = 1f;
        screenDefinitions[currentScreenID].screenController.ScreenEnter();
    }

    public void ChangeScreen(eScreenIDs _toScreenID)
    {
        if (changeScreenCoroutine != null)
            return;

        previousScreenID = currentScreenID;
        currentScreenID = (int)_toScreenID;

        changeScreenCoroutine = StartCoroutine(ChangeScreenRoutine());
    }

    private void Awake()
    {
        Initialize();
    }

    private IEnumerator ChangeScreenRoutine()
    {
        if (screenDefinitions[previousScreenID].screenTransitionType != eScreenTransitionType.None)
        {
            if(screenDefinitions[previousScreenID].screenTransitionType == eScreenTransitionType.Canvas_Fade)
            {
                yield return FadeOutScreenCanvas(previousScreenID);
            }
        }

        screenDefinitions[previousScreenID].screenController.ScreenExit();
        screenDefinitions[previousScreenID].screenGo.SetActive(false);
        screenDefinitions[currentScreenID].screenGo.SetActive(true);

        if (screenDefinitions[currentScreenID].screenTransitionType != eScreenTransitionType.None)
        {
            if (screenDefinitions[currentScreenID].screenTransitionType == eScreenTransitionType.Canvas_Fade)
            {
                yield return FadeInScreenCanvas(currentScreenID);
            }
            else if (screenDefinitions[currentScreenID].screenTransitionType == eScreenTransitionType.Color_Fade)
            {
                yield return FadeColorTransition();
            }
        }

        screenDefinitions[currentScreenID].screenController.ScreenEnter();
        

        changeScreenCoroutine = null;

        yield return null;
    }

    private IEnumerator FadeOutScreenCanvas(int _id)
    {
        screenDefinitions[_id].screenController.CanvasGroup.alpha = 1f;
        fadeTween = screenDefinitions[_id].screenController.CanvasGroup.DOFade(0f, screenDefinitions[_id].screenTransitionDuration).SetEase(Ease.OutSine);

        while(fadeTween.IsPlaying())
        {
            yield return null;
        }
    }

    private IEnumerator FadeInScreenCanvas(int _id)
    {
        screenDefinitions[_id].screenController.CanvasGroup.alpha = 0f;
        fadeTween = screenDefinitions[_id].screenController.CanvasGroup.DOFade(1f, screenDefinitions[_id].screenTransitionDuration).SetEase(Ease.InSine);

        while (fadeTween.IsPlaying())
        {
            yield return null;
        }
    }

    private IEnumerator FadeColorTransition()
    {
        Color transitionColor = screenDefinitions[currentScreenID].screenTransitionColor;
        transitionColor.a = 0f;
        colorFadeImage.color = transitionColor;

        fadeTween = colorFadeImage.DOFade(1f, screenDefinitions[currentScreenID].screenTransitionDuration).SetEase(Ease.InSine);

        while (fadeTween.IsPlaying())
        {
            yield return null;
        }

        fadeTween = colorFadeImage.DOFade(0f, screenDefinitions[currentScreenID].screenTransitionDuration).SetEase(Ease.OutSine);

        while (fadeTween.IsPlaying())
        {
            yield return null;
        }
    }
}
