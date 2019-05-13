using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScript : MonoBehaviour
{
    public Transform spawnPoint;
    private bool isHiding = false;
    public new Camera camera;
    public GameObject PlayerObject;
    private GameManagerScript gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManger").GetComponent<GameManagerScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown("space"))
            {
                if (!isHiding)
                {
                    Destroy(GameObject.Find("Player"));
                    isHiding = true;
                    UpdateHiding(isHiding);
                    camera.enabled = true;
                }
                else
                {
                    isHiding = false;
                    UpdateHiding(isHiding);
                    camera.enabled = false;
                }
            }
        }
    }

    private void UpdateHiding(bool status)
    {
        gameManager.updatePlayerHide(status);
    }
}
