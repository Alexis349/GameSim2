using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeMonsterScript : MonoBehaviour
{
    private AudioSource taunt;
    private float tauntTime = 5.0f;

    private void Start()
    {
        taunt = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        tauntTime -= Time.deltaTime;
        if (tauntTime <= 0.0f)
        {
            taunt.Play();
            tauntTime = 15.0f;
        }
    }
}
