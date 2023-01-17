using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public int health;
    public int score;

    public GameObject player;
    public GameObject sceneManagerScript;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            Die();
            return;
        }
        if (player.transform.position.y < -10.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        sceneManagerScript.GetComponent<SceneManagerScript>().RestartCurrentLevel();
    }
}
