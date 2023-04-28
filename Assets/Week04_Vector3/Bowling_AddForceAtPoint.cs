using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowling_AddForceAtPoint : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float forceAmount = 100f;
    public Transform redDot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1)
        {
            transform.position = new Vector3(0, 0.5f, -10);
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }
    }

    private void OnMouseDown()
    {
        var Dir = transform.position - redDot.position;
        rb.AddForceAtPosition(Dir * forceAmount, redDot.position);
    }
}
