using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    Rigidbody rb;
    public float forceAmount = 100f;
    public Transform redDot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * forceAmount);
    }

    
    void Update()
    {
        if(transform.position.y < -1)
        {
            transform.position = new Vector3(0, 0.5f, -10);
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }
    }

    private void OnMouseDown()
    {
        //rb.AddForce(transform.forward * forceAmount);
        var Dir = transform.position - redDot.position;
        rb.AddForceAtPosition(Dir * forceAmount, redDot.position);
    }
}
