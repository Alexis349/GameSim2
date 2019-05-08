using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;
    private string playerRoom;
    private bool isPlayerHiding;
    private int puzzleLevel = 1;
    public GameObject AISpawnPoint;
    public GameObject AIPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void UpdatePuzzle()
    {
        puzzleLevel++;
    }

    public void SpawnAI()
    {
        Instantiate(AIPrefab, AISpawnPoint.transform.position, AISpawnPoint.transform.rotation);
    }

    //DELETE THIS
    private void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            SpawnAI();
        }
    }
}
