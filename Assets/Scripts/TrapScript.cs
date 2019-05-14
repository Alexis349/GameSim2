using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    //0 will be idle
    //1 will be active
    private int state = 0;
    private float spawnTimer = 5.0f;
    private GameManagerScript gameManager;
    private AudioSource audio;

    void Start()
    {
        gameManager = GameObject.Find("GameManger").GetComponent<GameManagerScript>();
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //handle the scripts state
        if (state == 0)
        {
            spawnTimer = 5.0f;
        }
        else if (state == 1)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0.0f)
            {
                CallGameManagerNPCSpawn();
                state = 0;
                print("Spawned Enemy!");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            state = 1;
            print("Player entered trap");
            if (!GameObject.Find("GameManger").GetComponent<GameManagerScript>().IsEnemySpawned())
            {
                audio.Play();
            }
        }
    }

    private void CallGameManagerNPCSpawn()
    {
        gameManager.SpawnAI();
    }
}
