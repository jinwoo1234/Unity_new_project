using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_PostEffects : MonoBehaviour
{
    public Shader myShader;
    Material myMaterial;

    Material material
    {
        get
        {
            if(myMaterial = null)
            {
                myMaterial = new Material(myShader);
                myMaterial.hideFlags = HideFlags.HideAndDontSave;
            }
            return myMaterial;
        }        
    }
    // Start is called before the first frame update
    void Start()
    {
        myShader = Shader.Find("My/Camera/PostEffect");
        GetComponent<Camera>().allowHDR = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GetComponent<Camera>().enabled)
        {
            return;
        }
    }


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(myShader != null)
        {
            
            Graphics.Blit(source, destination, myMaterial, 0);
        }
    }

    private void OnDisable()
    {
        if(myMaterial)
        {
            DestroyImmediate(myMaterial);
        }
    }

}
