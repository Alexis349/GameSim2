using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    private GameManagerScript gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManger").GetComponent<GameManagerScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameManager.PuzzleComplete())
            {
                Application.Quit();
            }
        }
    }
}
