using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.attachedRigidbody.CompareTag("enemy"))
        {
            DestroyObject(other.gameObject, 0.5F);
        }
    }
}
