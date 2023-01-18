using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemyScript : MonoBehaviour
{
    public GameObject player;
    private bool dead;
    public float speed;
    private bool seenPlayer;
    private int direction;
    private const int LEFT = -1;
    private const int RIGHT = 1;
    public Animator enemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        direction = LEFT;
        seenPlayer = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dead)
        {
            WalkTowards();
        }
    }

    void WalkTowards()
    {
        CheckEnemy();
        CheckEdge();
        transform.localScale = new Vector3(direction,1,1);
        enemyAnimator.SetFloat("Speed", speed);
        if (seenPlayer)
        {
            Vector3 target = player.transform.position;
            if (target.x < transform.position.x)
            {
                direction = LEFT;
            }
            else
            {
                direction = RIGHT;
            }
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }
        else
        {
            Vector3 current = transform.position;
            Vector3 target = new Vector3(current.x + direction, current.y, current.z);
            transform.position = Vector3.MoveTowards(current, target, speed);
        }
    }

    /**
     * Checks in enemy's direction for the player
     */
    void CheckEnemy()
    {
        Vector2 checker = transform.position;
        Vector2 target = new Vector2(direction, 0);
        RaycastHit2D rayHit = Physics2D.Raycast(checker, target, 1.0f, LayerMask.GetMask("Player"));
        if (rayHit.collider != null && rayHit.collider.CompareTag("Player"))    //checking if hit object is player
        {
            Debug.DrawRay(checker,target,Color.green);
            seenPlayer = true;
            return;
        }
        Debug.DrawRay(checker,target,Color.white);
    }

    /**
     * Checks for edge in front of enemy and change direction on edge
     */
    bool CheckEdge()
    {
        Vector2 position = transform.position;
        Vector2 checker = position + new Vector2(direction * 0.15f, 0);
        RaycastHit2D rayHit = Physics2D.Raycast(checker, Vector2.down, 1.0f);
        if (rayHit.collider == null)
        {
            if (seenPlayer) {seenPlayer = false;}
            Debug.DrawRay(checker,Vector3.down,Color.green);
            direction = -direction; //changing direction if close to edge
            return true;
        }
        Debug.DrawRay(checker,Vector3.down,Color.white);
        return false;
    }

    public void Die()
    {
        enemyAnimator.SetBool("Dead", true);
        dead = true;
    }
}
