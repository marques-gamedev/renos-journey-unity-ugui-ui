using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Button play_Bt;
    [SerializeField]
    private Button options_Bt;
    [SerializeField]
    private Button quit_Bt;

    private void Awake()
    {
        play_Bt.onClick.AddListener(Play_Button_Click);
        options_Bt.onClick.AddListener(Options_Button_Click);
        quit_Bt.onClick.AddListener(Quit_Button_Click);
    }

    public void Play_Button_Click()
    {
        // Load the game
        Debug.Log("Play");
    }

    public void Options_Button_Click()
    {
        // Open options menu
        Debug.Log("Options");
    }

    public void Quit_Button_Click()
    {
        RuntimeManager.Instance.QuitGame();
    }
}
