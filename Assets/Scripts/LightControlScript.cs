using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControlScript : MonoBehaviour
{
    private GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManger").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.GetGeneratorStatus())
        {
            this.GetComponent<Light>().enabled = false;
        }
        else
        {
            this.GetComponent<Light>().enabled = true;
        }
    }
}
