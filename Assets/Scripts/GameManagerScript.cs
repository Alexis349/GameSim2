using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;

    private string playerRoom = "MainMenu";
    private bool isPlayerHiding = false;
    private bool enemySpawned = false;
    private bool puzzleComplete = false;
    private bool isGeneratorOn = false;
    private bool freezerDoorOpen = false;
    private bool musicIsPlaying = false;

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
            AISpawnPoint.GetComponent<AudioSource>().Play();
        }
        else
        {
            return;
        }
    }

    public void ChangeLevel()
    {
        enemySpawned = false;
        musicIsPlaying = false;
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

    //Update our game with stuff
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

        //open the freezer door if generator is on
        if (GameObject.FindGameObjectWithTag("FreezerLockedDoor"))
        {
            if (!freezerDoorOpen)
            {
                if (isGeneratorOn)
                {
                    freezerDoorOpen = true;
                    GameObject.Find("Door").GetComponent<UnlockFreezerScript>().MoveDoor();
                }
            }
            else
            {
                GameObject.Find("Door").GetComponent<UnlockFreezerScript>().MoveDoor();
            }
        }

        //play some looping panic music
        if (enemySpawned)
        {
            if (!musicIsPlaying)
            {
                musicIsPlaying = true;
                AudioSource panicMusic = GameObject.FindGameObjectWithTag("MainCamera").AddComponent<AudioSource>();
                panicMusic.clip = Resources.Load<AudioClip>("Audio/SFX/panic_music");
                panicMusic.volume = 0.5f;
                panicMusic.loop = true;
                panicMusic.Play();
            }
        }
    }

    //this func isn't being used anymore for now
    public void updatePlayerHide(bool status)
    {
        isPlayerHiding = status;
    }
    //------------------------------------------

    public void UpdatePuzzleStatus()
    {
        puzzleComplete = true;
    }

    public bool PuzzleComplete()
    {
        return puzzleComplete;
    }

    public bool GetGeneratorStatus()
    {
        return isGeneratorOn;
    }

    public void TurnOnGenerator()
    {
        isGeneratorOn = true;
    }

    public bool IsEnemySpawned()
    {
        return enemySpawned;
    }
}
