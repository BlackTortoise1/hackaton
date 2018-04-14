using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}


    private void OnTriggerEnter(Collider other)
    {
        print("triggered");
        if(other.attachedRigidbody.CompareTag("Hero"))
        {
            print("player");
            //send event to player
            print(other.gameObject.name);
            other.attachedRigidbody.gameObject.GetComponent<PlayerActionsScript>().EnteredTrigger(tag);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
