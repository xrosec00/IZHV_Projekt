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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        if(movement != 0)
        {
            if (movement < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            Debug.Log("Movement" + movement);
            myAnimator.SetFloat("Speed", speed);
            transform.position += new Vector3(movement * speed, 0.0f, 0.0f);
            Debug.Log("Transform" + transform.position);
        }
        else
        {
            myAnimator.SetFloat("Speed", 0.0f);
        }
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    public void Jump()
    {
        Debug.Log("Jump");
        myAnimator.SetBool("Jump", true);
        //TODO
    }

    public void OnMove(InputAction value)
    {
    }
}
