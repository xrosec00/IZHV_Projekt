using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public GameObject player;

    public PlayerLogic plLogic;
    public SceneManagerScript mSceneMgrScript;
    private bool paused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerHit()
    {
        plLogic.getHit();
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
