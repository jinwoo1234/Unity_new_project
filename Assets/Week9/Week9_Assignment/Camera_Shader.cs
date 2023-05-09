using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Shader : MonoBehaviour
{
    Shader myShader;
    Material myMaterial;
    public float depth = 1f;

    // Start is called before the first frame update
    void Start()
    {
        myShader = Shader.Find("My2/PostEffects/Camera_Shader");
        myMaterial = new Material(myShader);
    }

    private void Update()
    {
        depth = Mathf.Clamp(depth, 0.0f, 1.0f);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        myMaterial.SetFloat("_Depth", depth);
        Graphics.Blit(source, destination, myMaterial, 0);
    }

    private void OnDisable()
    {
        DestroyImmediate(myMaterial);
    }
}
