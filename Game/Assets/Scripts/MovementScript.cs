﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    //Movement axis
    float h;
    float v;

    //Hit variable
    float hit;
    float slash;
    bool inHit;
    bool inAir;
    [HideInInspector]
    public bool canCast;
    [HideInInspector]
    public int type = 0;
    //Camera camera;

    //Settings
    public float speed = 1f;
    public float rotationSpeed = 0.5f;
    public float jumpPower = 3f;
    public string horizontal;
    public string vertical;
    public string punchAttack;
    public string slashAttack;
    public GameObject FireAttack;
    public GameObject IceAttack;
    //Animator
    Animator animator;

    void StartInHit()
    {
        inHit = true;
    }

    void EndInHit()
    {
        inHit = false;
    }

    void StartInAir()
    {
        inAir = true;
    }

    void EndInAir()
    {
        inAir = false;
    }

    public bool isInHit()
    {
        return inHit;
    }

	void Start () {
    //   camera = FindObjectOfType<Camera>();
        animator = GetComponent<Animator>();
        inHit = false;
        type = 1;

    }

    IEnumerator AnimEnder()
    {
        //Debug.Log("Started coroutine");
        
        string name = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        //Debug.Log(name);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);

     
        EndInHit();
        
        if (name.CompareTo("SpellCast") == 0)
        {
            Debug.Log("SpellCast");
            if (GameState.Instance.CurrentAbility == GameState.MarshmallowAbility.fire)
            {
                GameObject attack = Instantiate(FireAttack);
                attack.transform.position = transform.position + transform.right.normalized;
                attack.transform.LookAt(transform);
                attack.transform.Rotate(0, 180, 0);
                Destroy(attack, 5);
            }
            if(GameState.Instance.CurrentAbility == GameState.MarshmallowAbility.ice)
            {
                GameObject attack = Instantiate(IceAttack);
                attack.transform.position = transform.position + transform.right.normalized;
                attack.transform.LookAt(transform);
                attack.transform.Rotate(0, 180, 0);
                Destroy(attack, 5);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        //Debug.Log(inHit);
        h = Input.GetAxis(horizontal);
        v = Input.GetAxis(vertical);
        float j = Input.GetAxis("Jump");
        hit = Input.GetAxis(punchAttack);
        slash = Input.GetAxis(slashAttack);
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 movement = new Vector3(-v, 0f, h);


        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);

        
        
        if (movement != Vector3.zero)
        {
            animator.SetBool("Walk", true);
            if (v != 0)
                transform.position += v * transform.right * speed * Time.deltaTime;
            if (h != 0)
                transform.position -= h * transform.forward * speed * Time.deltaTime;

        }
        else
        {
            animator.SetBool("Walk", false);
        }


        if (hit == 1)
        {
            animator.SetBool("Hit", true);
            //inHit = true;
            //return;
        }
        else
        {
            animator.SetBool("Hit", false);
        }

        if(slash == 1)
        {
            animator.SetBool("Slash", true);
            //inHit = true;
        }
        else
        {
            animator.SetBool("Slash", false);
        }
        
        if(j>0 && GetComponent<ManageUIScript>().EnergyBar.fillAmount == 1)
        {
            GetComponent<ManageUIScript>().EnergyBar.fillAmount = 0;
            animator.SetBool("Jump", true);
            if(rb != null)
            {
                rb.AddForce(rb.mass * new Vector3(0, jumpPower, 0),ForceMode.Impulse);
            }
            return;
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        //Debug.Log(movement.normalized);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            //EndInAir();
        }

    }
}
