using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionsScript : MonoBehaviour {

    private bool Interacting;
    private string ObjTag;

	// Use this for initialization
	void Start () {
        Interacting = false;
        ObjTag = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (Interacting && Input.GetKey(KeyCode.I))
            ActivateInteraction();

	}

    public void EnteredTrigger(string InteractionObjTag)
    {
        if (Interacting)
            return;

        Interacting = true;
        ObjTag = InteractionObjTag;
    }

    public void LeftTrigger(string InteractionObjTag)
    {
        if (!Interacting)
            return;

        Interacting = false;
        ObjTag = "";
    }


    void ActivateInteraction()
    {
        Debug.Log("Received I input " + ObjTag);

       if(ObjTag.Equals("Hot_COCO"))
            GameState.Instance.PlayerIsReckless(GameState.MarshmallowAbility.fire);
       if (ObjTag.Equals("Freezer"))
            GameState.Instance.PlayerIsReckless(GameState.MarshmallowAbility.ice);
       if (ObjTag.Equals("Microwave"))
            GameState.Instance.PlayerIsReckless(GameState.MarshmallowAbility.expanded);

                
    }
}
