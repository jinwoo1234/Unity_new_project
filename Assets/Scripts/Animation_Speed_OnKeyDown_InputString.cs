using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Speed_OnKeyDown_InputString : MonoBehaviour
{
    public string PlayKey, StopKey;
    Animator Anim;

    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            string s = Input.inputString.ToLower();
            if (s == PlayKey.ToLower())
            {
                Anim.speed = 1.0f;
                print("P");
            }

            if (s == StopKey.ToLower())
            {
                Anim.speed = 0.0f;
                print("n");
            }
        }
    }
}
