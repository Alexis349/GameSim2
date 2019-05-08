using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player").transform;
        agent.SetDestination(target.position);
    }
}
