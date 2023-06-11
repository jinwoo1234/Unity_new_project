using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class week13_Agent : MonoBehaviour
{
    public Transform Target;
    NavMeshAgent Agent;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Agent.destination = Target.position;
    }
}
