using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bowling_ParentController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int Cylinders = transform.childCount;
        print(Cylinders);
        if(Cylinders <= 0)
        {
            SceneManager.LoadScene("week04_BowlingGame");
        }
    }
}
