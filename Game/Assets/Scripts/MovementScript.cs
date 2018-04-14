using System.Collections;
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
    bool inJump;
    bool inSquash;
    //Camera camera;

    //Settings
    public float speed = 1f;
    public float rotationSpeed = 0.5f;
    public string horizontal;
    public string vertical;
    public string punchAttack;
    public string slashAttack;
    //Animator
    Animator animator;

    void StartInHit()
    {
        inHit = true;
    }

    void StartJump()
    {
        inJump = true;
    }

    void EndJump()
    {
        inJump = false;
    }

    void StartSquash()
    {
        inSquash = true;
    }

    void EndSquash()
    {
        inSquash = false;
    }

    void EndInHit()
    {
        inHit = false;
    }

    public bool isInHit()
    {
        return inHit;
    }

	void Start () {
    //   camera = FindObjectOfType<Camera>();
        animator = GetComponent<Animator>();
        inHit = false;
        inJump = false;
        inSquash = false;

    }

    IEnumerator AnimEnder()
    {
        //Debug.Log("Started coroutine");
        
        string name = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        //Debug.Log(name);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);

        if (name.CompareTo("Punch") == 0)
        {
            //Debug.Log("PunchEnd");
            EndInHit();
        }

        if (name.CompareTo("Slash") == 0)
        {
            //Debug.Log("SlashEnd");
            EndInHit();
        }

        if (name.CompareTo("Jump") == 0)
        {
            //Debug.Log("JumpEnd");
            EndJump();
        }

        if (name.CompareTo("Squash") == 0)
        {
            //Debug.Log("SquashEnd");
            EndSquash();
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
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
        
        if (movement != Vector3.zero && !inHit)
        {
            if(v > 0)
                transform.position += transform.right * speed * Time.deltaTime;
            if(v < 0)
                transform.position -= transform.right * speed * Time.deltaTime;

            if (h < 0)
                transform.position += transform.forward * speed * Time.deltaTime;
            if (h > 0)
                transform.position -= transform.forward * speed * Time.deltaTime;


            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }



        if(hit == 1 && !inJump && !inHit)
        {
            animator.SetBool("Hit", true);
        }
        else
        {
            animator.SetBool("Hit", false);
        }

        if(slash == 1 && !inJump && !inHit)
        {
            animator.SetBool("Slash", true);
        }
        else
        {
            animator.SetBool("Slash", false);
        }
        
        if(j>0 && !inJump && !inHit)
        {
            animator.SetBool("Jump", true);
            if(rb != null)
            {
                rb.AddForce(rb.mass * new Vector3(0, 10, 0));
            }
        }
        else
        {
            animator.SetBool("Jump", false);
        }
        //Debug.Log(movement.normalized);
    }
}
