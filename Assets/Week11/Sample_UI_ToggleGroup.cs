using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sample_UI_ToggleGroup : MonoBehaviour
{
    public ToggleGroup toggleGroup;

    // Start is called before the first frame update
    void Start()
    {
        toggleGroup.SetAllTogglesOff();
    }

    public void GetActiveToggle()
    {
        IEnumerable<Toggle> ActiveToggle = toggleGroup.ActiveToggles();
        foreach(Toggle toggle in ActiveToggle)
        {
            print(toggle);
        }
    }
}
