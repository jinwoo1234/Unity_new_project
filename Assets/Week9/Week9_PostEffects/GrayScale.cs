using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayScale : MonoBehaviour
{
    Shader myShader;
    Material myMaterial;
    public float grayScaleAmount = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        myShader = Shader.Find("MY/PostEffects/GrayScale");
        myMaterial = new Material(myShader);
    }

    // Update is called once per frame
    void Update()
    {
        grayScaleAmount = Mathf.Clamp(grayScaleAmount, 0.0f, 1.0f);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        myMaterial.SetFloat("_GrayScaleAmount", grayScaleAmount);
        Graphics.Blit(source, destination, myMaterial);
    }

    private void OnDisable()
    {
        DestroyImmediate(myMaterial);
    }
}
