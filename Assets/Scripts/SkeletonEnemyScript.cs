using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkeletonEnemyScript : MonoBehaviour
{
    public GameObject player;
    private bool hit;
    public float speed;
    private bool seenPlayer;
    private int direction;
    private const int LEFT = -1;
    private const int RIGHT = 1;
    public Animator enemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        direction = RIGHT; //FIXME
        seenPlayer = true;  //FIXME
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WalkTowards();
    }

    void WalkTowards()
    {
        CheckEdge();
        transform.localScale = new Vector3(direction,1,1);
        enemyAnimator.SetFloat("Speed", speed);
        if (seenPlayer) //FIXME
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
    
    void Move()
    {
        transform.localScale = new Vector3(direction, 0, 0);
        transform.position += new Vector3(direction * speed, 0, 0);
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
}
