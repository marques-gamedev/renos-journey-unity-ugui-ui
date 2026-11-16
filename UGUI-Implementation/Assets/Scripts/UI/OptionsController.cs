using UnityEngine;

public class OptionsController : ScreenController
{
    public override void ScreenEnter()
    {
        gameObject.SetActive(true);
    }

    public override void ScreenExit()
    {
        gameObject.SetActive(false);
    }
}
