using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItemScript : MonoBehaviour
{
    public string textToDisplay;
    private bool noteToggle = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown("space"))
            {
                //display message
                //if !noteToggle then noteToggle = true; Display textToDisplay;
                print("Used note");
                print(noteToggle);
                noteToggle = !noteToggle;
            }
        }
    }
}
