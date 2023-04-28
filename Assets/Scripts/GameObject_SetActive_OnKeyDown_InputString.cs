using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject_SetActive_OnKeyDown_InputString : MonoBehaviour
{
    public GameObject On, Off;
    public string TargetKey;

    private void Start()
    {
        On.SetActive(false);
        Off.SetActive(true);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if(Input.inputString.ToLower() == TargetKey.ToLower())
            {
                if(On.activeSelf) {
                    On.SetActive(false);
                    Off.SetActive(true);
                }
                else
                {
                    On.SetActive(true);
                    Off.SetActive(false);
                }
            }
        }
    }
}
