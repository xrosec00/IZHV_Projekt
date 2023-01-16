using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public PlayerInput myPlayerInput;
    public Animator myAnimator;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
    {
        Debug.Log("Jump");
        //TODO
    }

    public void Move(InputAction.CallbackContext con)
    {
        Debug.Log(con);
        Vector2 direction = con.ReadValue<Vector2>();
        myAnimator.SetFloat("Move", speed);
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime;
    }
}
