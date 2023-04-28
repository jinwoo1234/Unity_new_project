using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bowling_Cylinder : MonoBehaviour
{
    GameObject Score;

    private void Start()
    {
        Score = GameObject.Find("Score");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Sphere")
        {
            int score = int.Parse(Score.GetComponent<TMP_Text>().text);
            score++;
            Score.GetComponent<TMP_Text>().text = score.ToString();
            Destroy(gameObject);
        }
    }
}
