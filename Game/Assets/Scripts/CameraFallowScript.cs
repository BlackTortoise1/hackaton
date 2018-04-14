using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallowScript : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object
    public float verticalSpeed = 0.5F;
    public float maxOYOffset = 1.1F;
    public float minOYOffset = -1.5F;

    private float OYOffset = 0;


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        
    }
    //Update is called each frame
    void Update()
    {
        transform.position = player.transform.TransformPoint(offset);
        
        float OxRot = verticalSpeed * Input.GetAxis("Mouse Y");
        OYOffset += OxRot;
        print(OYOffset);
        OYOffset = Mathf.Clamp(OYOffset, minOYOffset, maxOYOffset);

        transform.LookAt(player.transform.position + new Vector3(0, OYOffset, 0));

    }
}

