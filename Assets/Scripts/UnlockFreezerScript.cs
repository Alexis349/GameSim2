using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockFreezerScript : MonoBehaviour
{
    private GameManagerScript gameManager;
    private Transform CurrPos;
    private Transform OpenPos;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.Find("GameManger").GetComponent<GameManagerScript>();
        //OpenPos.position += Vector3.forward*2;
        CurrPos = this.transform;
    }

    // Update is called once per frame
    /*void Update()
    {
        if (gameManager.GetGeneratorStatus())
        {
            CurrPos = OpenPos;
        }
    }*/
    public void MoveDoor()
    {
        CurrPos.position += Vector3.forward * 2;
    }
}
