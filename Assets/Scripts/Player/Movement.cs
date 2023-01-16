using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public PlayerInput myPlayerInput;
    public Animator myAnimator;
    public float speed;
    public bool grounded;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    public void OnJump(InputAction.CallbackContext con)
    {
        if (!grounded)
        {
            return;
        }
        myAnimator.SetBool("Jump", true);
        myRigidBody.AddForce(new Vector2(0.0f,jumpForce), ForceMode2D.Impulse);
    }

    private void Move()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        if(movement != 0)
        {
            if(movement < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            myAnimator.SetFloat("Speed", speed);
            transform.position += new Vector3(movement * speed, 0.0f, 0.0f);
        }
        else
        {
            myAnimator.SetFloat("Speed", 0.0f);
        }
    }

    public void OnAttack(InputAction.CallbackContext con)
    {
        myAnimator.SetBool("Attack", true);
        //TODO
        StartCoroutine(waitFor());
        
    }

    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(0.5f);
        myAnimator.SetBool("Attack", false);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log("YEEET");
        if (collider.gameObject.name == "ground")
        {
            grounded = true;
            myAnimator.SetBool("Grounded", true);
            myAnimator.SetBool("Jump", false);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "ground")
        {
            grounded = false;
            myAnimator.SetBool("Grounded", false);
        }
    }
}
