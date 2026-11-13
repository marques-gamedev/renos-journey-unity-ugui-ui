using UnityEngine;

public enum eScreenTransitionType { Color_Fade }

public struct ScreenDefinition
{
    [SerializeField]
    private GameObject screenGo;
    private eScreenTransitionType screenTransitionType;
    private Color screenTransitionColor;
    private float screenTransitionDuration;
}

public class ScreenManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
