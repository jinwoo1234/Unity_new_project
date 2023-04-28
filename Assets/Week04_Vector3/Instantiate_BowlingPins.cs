using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate_BowlingPins : MonoBehaviour
{
    public GameObject BowlingPin;
    // Start is called before the first frame update
    void Start()
    {
        InstantiatePins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiatePins()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject Pin = Instantiate(BowlingPin);
            Pin.transform.SetParent(transform);
            Pin.transform.position += transform.position + Vector3.right * i * 2f;
        }
    }
}
