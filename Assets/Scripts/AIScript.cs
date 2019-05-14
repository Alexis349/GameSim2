using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    public AudioSource taunt;
    public AudioSource Chase;
    private int cycle = 0;
    private float tauntTimer = 10.0f;

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        taunt = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.SetDestination(target.position);
        tauntTimer -= Time.deltaTime;
        if (tauntTimer <= 0.0f)
        {
            if (cycle == 0)
            {
                taunt.Play();
                tauntTimer = 4.0f;
                cycle = 1;
            }
            else if (cycle == 1)
            {
                Chase.Play();
                tauntTimer = 10.0f;
                cycle = 0;
            }
            
        }
    }
}
