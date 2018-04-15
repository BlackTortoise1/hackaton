using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    public Vector3 HotAbilityColor;
    public Vector3 IceAbilityColor;
    public Vector3 ExpandAbilityColor;

    private Vector3 DefaultColor;

    // Use this for initialization
    void Start () {
        Color aux = obj1.GetComponent<Renderer>().material.color;
        DefaultColor = new Vector3(aux.r, aux.g, aux.b);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeColorIn(GameState.MarshmallowAbility ability)
    {
        if(ability == GameState.MarshmallowAbility.fire)
        {
            Color aux = obj1.GetComponent<Renderer>().material.color;
            aux.r = HotAbilityColor.x; aux.g = HotAbilityColor.y; aux.b = HotAbilityColor.z;
            obj1.GetComponent<Renderer>().material.color = aux;
        }

        if (ability == GameState.MarshmallowAbility.ice)
        {
            Color aux = obj1.GetComponent<Renderer>().material.color;
            aux.r = IceAbilityColor.x; aux.g = IceAbilityColor.y; aux.b = IceAbilityColor.z;
            obj1.GetComponent<Renderer>().material.color = aux;
        }

        if (ability == GameState.MarshmallowAbility.expanded)
        {
            Color aux = obj1.GetComponent<Renderer>().material.color;
            aux.r = ExpandAbilityColor.x; aux.g = ExpandAbilityColor.y; aux.b = ExpandAbilityColor.z;
            obj1.GetComponent<Renderer>().material.color = aux;
        }

        if (ability == GameState.MarshmallowAbility.normal)
        {
            Color aux = obj1.GetComponent<Renderer>().material.color;
            aux.r = DefaultColor.x; aux.g = DefaultColor.y; aux.b = DefaultColor.z;
            obj1.GetComponent<Renderer>().material.color = aux;
        }
    }

}
