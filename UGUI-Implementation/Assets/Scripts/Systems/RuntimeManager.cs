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

    public void QuitGame()
    {        
        Application.Quit();
    }
}
