using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowling_InstantiatePins : MonoBehaviour
{
    public GameObject MyCylinder;
    public Transform StartPoint;
    public Transform Parent;

    private void Start()
    {
        InstantiateCylinders();
    }
    void InstantiateCylinders()
    {
        for(int i = 0; i <5; i++)
        {
            GameObject Clone = Instantiate(MyCylinder);
            Clone.transform.position = StartPoint.position + Vector3.left * 4 + Vector3.right * i * 2 + Vector3.up;
            Clone.transform.SetParent(Parent);
        }
    }
}
