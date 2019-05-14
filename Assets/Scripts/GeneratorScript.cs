using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    private GameManagerScript gameManager;
    public Light light;
    private AudioSource genLoop;
    private bool soundIsPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        genLoop = this.GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManger").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetGeneratorStatus())
        {
            light.color = Color.red;
        }
        else
        {
            light.color = Color.green;
        }

        if (gameManager.GetGeneratorStatus())
        {
            if (!soundIsPlaying)
            {
                genLoop.Play();
                soundIsPlaying = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown("space"))
            {
                if (!gameManager.GetGeneratorStatus())
                {
                    gameManager.TurnOnGenerator();
                    genLoop.Play();
                }
            }
        }
    }
}
