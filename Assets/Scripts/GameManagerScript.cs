using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;

    //start the player off in the breakroom spawnpoint
    private string playerRoom = "MainMenu";
    private bool isPlayerHiding = false;
    private bool enemySpawned = false;
    private bool puzzleComplete = false;

    public GameObject AISpawnPoint;
    public GameObject AIPrefab;
    public GameObject PlayerPrefab;

    private GameObject PlayerSpawnPoint;

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

    private void SpawnPlayer()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("PlayerSpawnPoint").Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag("PlayerSpawnPoint")[i].GetComponent<PlayerSpawnPointScript>().SpawnPointID == playerRoom)
            {
                Instantiate(PlayerPrefab, GameObject.FindGameObjectsWithTag("PlayerSpawnPoint")[i].transform.position, GameObject.FindGameObjectsWithTag("PlayerSpawnPoint")[i].transform.rotation);
            }
        }
    }

    //this function is for doors to use
    public void SetSpawnPoint(string IDName)
    {
        this.playerRoom = IDName;
    }

    private void setAISpawnPoint()
    {
        AISpawnPoint = GameObject.Find("AISpawnPoint");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != playerRoom)
        {
            if (SceneManager.GetActiveScene().name != "Hallways")
            {
                setAISpawnPoint();
                playerRoom = SceneManager.GetActiveScene().name;
            }
            else
            {
                setAISpawnPoint();
            }
        }
        
        //spawn the player in each scene according to spawnpoint
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            print("We have a player");
        }
        else if (!isPlayerHiding)
        {
            SpawnPlayer();
        }
        print(playerRoom);
    }

    public void updatePlayerHide(bool status)
    {
        isPlayerHiding = status;
    }

    public void UpdatePuzzleStatus()
    {
        puzzleComplete = true;
    }

    public bool PuzzleComplete()
    {
        return puzzleComplete;
    }
}
