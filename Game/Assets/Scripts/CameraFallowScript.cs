using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallowScript : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object
    public float verticalSpeed = 0.5F;
    public float maxOYOffset = 1.1F;
    public float minOYOffset = -1.5F;

    private float OYOffset = 0;

    private float MaxCameraShake = 0.0F;
    private int CameraShakeDirection = 1;


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
        if(GameState.Instance.Respawning && (GameState.Instance.ELapsedRespawnTime > GameState.Instance.SpawnDontMoveTime))
        {
            transform.position += new Vector3(0, 0, Time.deltaTime * CameraShakeDirection);
            MaxCameraShake += Time.deltaTime * CameraShakeDirection;
            if(Mathf.Abs(MaxCameraShake) > 0.2)
            {
                MaxCameraShake = 0;
                CameraShakeDirection = (CameraShakeDirection == 1) ? -1 : 1;
            }
            return;
        }

        transform.position = player.transform.TransformPoint(offset);
        
        float OxRot = verticalSpeed * Input.GetAxis("Mouse Y");
        OYOffset += OxRot;
        //print(OYOffset);
        OYOffset = Mathf.Clamp(OYOffset, minOYOffset, maxOYOffset);

        transform.LookAt(player.transform.position + new Vector3(0, OYOffset, 0));

    }
}

