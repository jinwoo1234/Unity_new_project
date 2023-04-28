using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDown_AddForce : MonoBehaviour
{
    public float force = 1000f;
    public Transform AimTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -2)
        {
            transform.position = new Vector3(0, 0.5f, -20f);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    private void OnMouseDown()
    {
        var Dir = gameObject.transform.position - AimTransform.position;
        GetComponent<Rigidbody>().AddForceAtPosition(Dir * force, AimTransform.position);
    }
}
