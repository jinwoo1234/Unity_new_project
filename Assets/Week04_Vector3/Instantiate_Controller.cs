using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_Controller : MonoBehaviour
{
    public GameObject MyCylinder;
    public Transform StartPosition;
    int ClickCount = 0;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InstantiateMyObject();
        }
    }

    void InstantiateMyObject()
    {
        //GameObject Clone = Instantiate(MyCylinder);
        //Clone.transform.position = new Vector3(Random.Range(-4, 4), 1f, Random.Range(-4, 4));
        //Destroy(Clone, 2);

        //Clone.transform.position = StartPosition.position + Vector3.right * ClickCount + Vector3.up;
        //ClickCount++;

        for (int i = 0; i < 5; i++)
        {
            GameObject Clone = Instantiate(MyCylinder);
            Clone.transform.position = StartPosition.position + Vector3.right * i * 2 + Vector3.up;
        }
    }
}
