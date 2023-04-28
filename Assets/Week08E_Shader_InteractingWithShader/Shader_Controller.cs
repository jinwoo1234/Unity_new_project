using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shader_Controller : MonoBehaviour
{
    int brightness;
    public GameObject GameObjectWithShader;

    Renderer MyRenderer;


    private void Start()
    {
        MyRenderer = GameObjectWithShader.GetComponent<Renderer>();
        brightness = 1;
        MyRenderer.material.SetInt("_Brightness", 1);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            brightness = -1 * brightness;
            MyRenderer.material.SetInt("_Brightness", brightness);
            print(gameObject.name + "," + brightness);
        }
    }
}
