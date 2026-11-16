using UnityEngine;

public abstract class ScreenController : MonoBehaviour
{
    public CanvasGroup CanvasGroup { get => canvasGroup; }

    [SerializeField] private CanvasGroup canvasGroup;

    public abstract void ScreenEnter();

    public abstract void ScreenExit();
}
