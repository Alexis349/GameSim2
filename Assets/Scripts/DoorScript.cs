using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public string sceneToLoad;
    private GameManagerScript gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManger").GetComponent<GameManagerScript>();
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("space"))
            {
                gameManager.ChangeLevel();
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
