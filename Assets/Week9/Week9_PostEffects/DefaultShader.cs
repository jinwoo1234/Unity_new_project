using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultShader : MonoBehaviour
{
    Shader myShader;
    Material myMaterial;

    // Start is called before the first frame update
    void Start()
    {
        myShader = Shader.Find("My/PostEffects/DefaultShader");
        myMaterial = new Material(myShader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, myMaterial, 0);
    }

    private void OnDisable()
    {
        DestroyImmediate(myMaterial);
    }
}
