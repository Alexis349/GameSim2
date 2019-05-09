using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;
    private string playerRoom;
    private bool isPlayerHiding;
    private int puzzleLevel = 1;
    private bool enemySpawned = false;
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
        if (!enemySpawned)
        {
            Instantiate(AIPrefab, AISpawnPoint.transform.position, AISpawnPoint.transform.rotation);
            enemySpawned = true;
        }
        else
        {
            return;
        }
    }

    public void ChangeLevel()
    {
        enemySpawned = false;
    }
}
