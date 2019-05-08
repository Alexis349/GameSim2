using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    //keeps track of how much total movement the mouse has made
    Vector2 mouseLook;
    //helps us smooth movement of mouse
    Vector2 smoothValue;
    public float sensitivity = 2.0f;
    public float smoothing = 2.0f;
    private const float MIN_Y_LOOK = -70.0f;
    private const float MAX_Y_LOOK = 70.0f;

    //the character gameobject that we are rotating with the camera
    GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        character = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //assuming we use vector2 because we don't need 3 axis for mouse input
        var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothValue.x = Mathf.Lerp(smoothValue.x, mouseDelta.x, 1f / smoothing);
        smoothValue.y = Mathf.Lerp(smoothValue.y, mouseDelta.y, 1f / smoothing);
        mouseLook += smoothValue;

        transform.localRotation = Quaternion.AngleAxis(-Mathf.Clamp(mouseLook.y, MIN_Y_LOOK, MAX_Y_LOOK), Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
