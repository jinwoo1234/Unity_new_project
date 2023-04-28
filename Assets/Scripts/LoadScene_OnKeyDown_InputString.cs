using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene_OnKeyDown_InputString : MonoBehaviour
{
    public string InputKey;
    public Object TargetScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            string s = Input.inputString.ToLower();
            if (s == InputKey.ToLower())
            {
                print("Load :" + TargetScene.name);
                SceneManager.LoadScene(TargetScene.name);
            }
        }
    }
}
