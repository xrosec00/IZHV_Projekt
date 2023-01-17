using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public int health;
    public int score;
    private bool paused;

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

    private void Die()
    {
        //mSceneManager.GetComponent<SceneManagerScript>().RestartCurrentLevel(); //TO DELETE
        mSceneMgrScript.RestartCurrentLevel();
    }

    public void Pause()
    {
        
        if (paused)
        {
            Time.timeScale = 1;
            paused = false;
            mSceneMgrScript.UnpauseGame();  //enables main menu UI, disables main scene UI
        }
        else
        {
            Time.timeScale = 0;
            paused = true;
            mSceneMgrScript.PauseGame();    //disables main menu UI, enables main scene UI
        }
    }
}
