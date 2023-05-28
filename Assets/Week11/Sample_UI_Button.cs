using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_UI_Button : MonoBehaviour
{
    public void OnClick_ButtonFunction()
    {
        print("Button Clicked");
    }

    public void OnClick_ButtonFunction(int value)
    {
        print(value + " is passed");
    }
    public void OnClick_ButtonFunction(string value)
    {
        print(value + " is passed");
    }
}
