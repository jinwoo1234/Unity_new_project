using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject_SetActiveToggle_OnKeyDown_InputString : MonoBehaviour
{
    public GameObject Target;
    public bool setActive;
    public string TargetKey;

    private void Start()
    {
        Target.SetActive(setActive);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.inputString.ToLower() == TargetKey.ToLower())
            {
                if (Target.activeSelf)
                {
                    Target.SetActive(false);
                }
                else
                {
                    Target.SetActive(true);
                }
            }
        }
    }
}
