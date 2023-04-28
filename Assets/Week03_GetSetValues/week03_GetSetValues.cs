using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class week03_GetSetValues : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(gameObject.name);
        print(gameObject.tag);
        print(gameObject.layer);
        print(gameObject.activeSelf);
        print(transform.position);
        print(transform.rotation);
        string s = GetComponent<AnotherScript>().myVar;
        print(s);
        GetComponent<AnotherScript>().MyFunction();
        AnotherScript AS = GetComponent<AnotherScript>();
        print(AS.myVar);
        AS.MyFunction();

        //gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Translate(0, 0, 1 * 0.01f);

    }
    public void MyButtonClick()
    {
        print("button clicked");
        if(gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void MoveForward()
    {
        transform.Translate(0,0,1);
    }

    public void MoveBackward()
    {
        transform.Translate(0, 0, -1);
    }

    public void TurnLeft()
    {
        transform.Rotate(0, -10, 0);
    }

    public void TurnRight()
    {
        transform.Rotate(0, 10, 0);
    }
}
