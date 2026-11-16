using UnityEngine;

public class RuntimeManager : MonoBehaviour
{
    private static RuntimeManager instance;
    public static RuntimeManager Instance
    {
        get
        {
            if(!instance)
            {
                instance = new GameObject().AddComponent<RuntimeManager>();
                instance.name = "RuntimeManager";
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    public ScreenManager ScreenManager
    {
        get
        {
            if (screenManager == null)
            {
                screenManager = FindAnyObjectByType<ScreenManager>();

                if (screenManager == null)
                {
                    Debug.LogError("EXCEPTION: Couldn't find any object with ScreenManager component.");
                }              
            }

            return screenManager;
        }
    }

    private ScreenManager screenManager;

    public void QuitGame()
    {        
        Application.Quit();
    }
}
