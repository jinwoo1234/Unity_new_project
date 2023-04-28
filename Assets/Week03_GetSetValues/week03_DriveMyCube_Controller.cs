using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class week03_DriveMyCube_Controller : MonoBehaviour
{
    float speed = 1.0f;
    int dir = 1;
    int score = 0;
    public GameObject Score;

    // Start is called before the first frame update
    void Start()
    {
        //string s = Score.GetComponent<TextMeshPro>().text;
        //print(s);
        //print(Score.GetComponent<TMP_Text>().text);
        Score.GetComponent<TMP_Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseH = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseH, 0);
        transform.Translate(0, 0, speed * dir * 0.01f);

        if(transform.position.y < -1)
        {
            SceneManager.LoadScene("week03_DriveMyCube");
        }
    }

    // move forward
    public void MoveForward()
    {
        //transform.Translate(0, 0, 1);
        dir = 1;
    }

    // move backward
    public void MoveBackward()
    {
        //transform.Translate(0, 0, -1);
        dir = -1;
    }

    public void Stop()
    {
        //transform.Translate(0, 0, 0);
        dir = 0;
    }

    // turn right
    public void TurnRight()
    {
        transform.Rotate(0, 10, 0);
    }

    // turn left
    public void TurnLeft()
    {
        transform.Rotate(0, -10, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        if(collision.gameObject.tag == "MySphere")
        {
            //print("you get +1");
            score++;
            print(score);
            Score.GetComponent<TMP_Text>().text = score.ToString();
        }

        if (collision.gameObject.tag == "MyCapsule")
        {
            //print("you get -1");
            score--;
            print(score);
            if(score < 0)
            {
                score = 0;
                SceneManager.LoadScene("week03_DriveMyCube");
            }
            Score.GetComponent<TMP_Text>().text = score.ToString();
        }
    }
}
