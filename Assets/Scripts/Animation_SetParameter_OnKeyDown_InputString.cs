using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_SetParameter_OnKeyDown_InputString : MonoBehaviour
{
    public string PlayKey, StopKey, ReverseKey;
    Animator Anim;

    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.SetFloat("Control", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            string s = Input.inputString.ToLower();
            if (s == PlayKey.ToLower())
            {
                Anim.SetFloat("Control", 1f);
                print("P");
            }

            if (s == StopKey.ToLower())
            {
                Anim.SetFloat("Control", 0f);
                print("n");
            }

            if (s == ReverseKey.ToLower())
            {
                Anim.SetFloat("Control", -1f);
                print("r");
            }
        }
    }
}
