using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public int health;
    public int score;
    public GameObject player;
    public GameObject mSceneManager;

    private SceneManagerScript mSceneMgrScript;

    private void Start()
    {
        mSceneMgrScript = mSceneManager.GetComponent<SceneManagerScript>();
    }
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

    /**
     * Function name: Die
     * Restarts the current scene, is called when player falls off platform or health reaches zero
     */
    private void Die()
    {
        mSceneMgrScript.RestartCurrentLevel();
    }

    /**
     * Lose a point of health when hit
     */
    public void getHit()
    {
        health -= 1;
        var mov = player.GetComponent<Movement>();
        mov.Knockback(1);       //FIXME
    }
}
