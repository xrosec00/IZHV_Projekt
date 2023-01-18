using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    public GameObject player;
    public GameObject invisibleWall;
    public PlayerLogic plLogic;
    public SceneManagerScript mSceneMgrScript;
    private bool paused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        MoveWall();
    }

    void PlayerHit()
    {
        plLogic.GetHit();
    }
    
    public void Pause()
    {
        if (paused)
        {
            Debug.Log("Unpausing game in Logic Manager");
            mSceneMgrScript.UnpauseGame();  //enables main menu UI, disables main scene UI
        }
        else
        {
            Debug.Log("Pausing game in Logic Manager");
            mSceneMgrScript.PauseGame();    //disables main menu UI, enables main scene UI
        }
    }

    private void MoveWall()
    {
        var difference = Mathf.Abs(invisibleWall.transform.position.x - player.transform.position.x);
        if (player.GetComponent<Movement>().getDirection() > 0 && difference > 15.0f)   //going right and keeping wall at 15 distance
        {
            invisibleWall.transform.position =
                new Vector3(player.transform.position.x - 15.0f, invisibleWall.transform.position.y);
        }
    }
    
    public void SetPause(bool isItPaused)
    {
        paused = isItPaused;
    }
}
