using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public PlayerInput myPlayerInput;
    public Animator myAnimator;
    public PlayerLogic myLogic;
    public float speed;
    public bool grounded;
    public float jumpForce;
    private int direction = 1;
    private bool attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Debug.DrawRay(transform.position, new Vector3(direction*0.32f, 0), Color.white);
        if (attack)
        {
            swordAttack();
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
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
                direction = -1; //LEFT
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                direction = 1; //RIGHT
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
        Debug.Log("On Attack direction " + direction);
        myAnimator.SetBool("Attack", true);
        attack = true;
        StartCoroutine(waitFor());
    }

    public void swordAttack()
    {
        Vector2 target = new Vector2(direction, 0);
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, target, 0.32f, LayerMask.GetMask("Default"));
        Debug.DrawRay(transform.position, new Vector3(direction*0.32f, 0), Color.red);
        if (rayHit.collider != null && rayHit.collider.CompareTag("Enemy"))
        {
            rayHit.collider.gameObject.GetComponent<EnemyLogic>().GetHit();
            myLogic.IncreaseScore(1);
        }
    }

    IEnumerator waitFor()
    {
        yield return new WaitForSeconds(0.5f);
        myAnimator.SetBool("Attack", false);
        attack = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            //TODO animate hit
            myLogic.GetHit();
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Platform"))
        {
            grounded = true;
            myAnimator.SetBool("Grounded", true);
            myAnimator.SetBool("Jump", false);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Platform"))
        {
            grounded = false;
            myAnimator.SetBool("Grounded", false);
        }
    }

    public int getDirection()
    {
        return direction;
    }
}
