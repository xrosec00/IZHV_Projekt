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
    // Start is called before the first frame update
    void Start()
    {
        direction = LEFT;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WalkTowards();
    }

    void WalkTowards()
    {
        Debug.Log("Walking towards");
        if (seenPlayer)
        {
            Vector3 target = player.transform.position;
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
        Debug.Log("In move: " + (direction*speed));
        transform.position += new Vector3(direction * speed, 0, 0);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            
        }
    }
}
