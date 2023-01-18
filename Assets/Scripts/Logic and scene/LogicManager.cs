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
        plLogic.GetHit();
    }
    
    public void Pause()
    {
        if (paused)
        {
            mSceneMgrScript.UnpauseGame();  //enables main menu UI, disables main scene UI
        }
        else
        {
            mSceneMgrScript.PauseGame();    //disables main menu UI, enables main scene UI
        }
    }

    public void SetPause(bool isItPaused)
    {
        paused = isItPaused;
    }
}
