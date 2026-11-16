using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : ScreenController
{
    [SerializeField]
    private Button playBt;
    [SerializeField]
    private Button optionsBt;
    [SerializeField]
    private Button quitBt;

    public override void ScreenEnter()
    {
        
    }

    public override void ScreenExit()
    {
        
    }

    public void PlayButtonClick()
    {
        // Load the game
        RuntimeManager.Instance.ScreenManager.ChangeScreen(eScreenIDs.Game);
    }

    public void OptionsButtonClick()
    {
        // Open options menu
        RuntimeManager.Instance.ScreenManager.ChangeScreen(eScreenIDs.Options);
    }

    public void QuitButtonClick()
    {
        RuntimeManager.Instance.QuitGame();
    }

    private void Awake()
    {
        playBt.onClick.AddListener(PlayButtonClick);
        optionsBt.onClick.AddListener(OptionsButtonClick);
        quitBt.onClick.AddListener(QuitButtonClick);
    }
}
