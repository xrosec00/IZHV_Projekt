using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/**
 * Class SpawnerManager
 * calls and manages the various platform and enemy spawners
 */
public class SpawnerManager : MonoBehaviour
{
    public GameObject player;

    public PlatformSpawner platformSpwn;
    public EnemySpawner enemySpawn;
    private Vector3 endOfPlatform;

    private int empties;        //keeps track of how many empty spaced in a row have spawned
    // Start is called before the first frame update
    void Start()
    {
        endOfPlatform = transform.position;
    }
    
    void FixedUpdate()
    {
        generatePlatform();
    }

    void generatePlatform()
    {
        var playerDirection = player.GetComponent<Movement>().getDirection();
        int difference = (int)endOfPlatform.x - (int)player.transform.position.x;
        if (playerDirection > 0)    //going right
        {
            if (difference == 3)
            {
                var decider = generateRandom();       //randomly decides what platform type will spawn if any
                if (decider < 4.0f)     //create 2 normal platforms 40% chance
                {
                    Platform();
                }
                else if (decider > 4.0f && decider < 6.0f) //generate half platform 20% chance
                {
                    HalfPlatform();
                }
                else if (decider > 6.0f && decider < 7.0f)
                {
                    Cloud();
                }
                else
                {
                    endOfPlatform = new Vector3(endOfPlatform.x + 0.64f, endOfPlatform.y);
                    empties += 1;
                }
            }
        }
    }

    void Platform()
    {
        platformSpwn.SpawnPlatform(endOfPlatform);
        endOfPlatform = new Vector3(endOfPlatform.x + 0.64f, endOfPlatform.y);
        platformSpwn.SpawnPlatform(endOfPlatform);
        var RandomEnemy = generateRandom();
        if (RandomEnemy < 3.0f)     //20% chance to spawn enemy
        {
            enemySpawn.SpawnEnemy(new Vector3(endOfPlatform.x, endOfPlatform.y + 0.5f));
        }
        endOfPlatform = new Vector3(endOfPlatform.x + 0.64f, endOfPlatform.y);
    }

    void HalfPlatform()
    {
        var height = RandomHeight(-0.2f, 0.7f);
        var pos = new Vector3(endOfPlatform.x, endOfPlatform.y + height);
        platformSpwn.SpawnHalfPlatform(pos);
        pos = new Vector3(endOfPlatform.x + 0.64f, endOfPlatform.y + height);
        platformSpwn.SpawnHalfPlatform(pos);
        endOfPlatform = new Vector3(endOfPlatform.x + Random.Range(1.28f, 1.92f), endOfPlatform.y);
        empties += 1; //we want a platform reasonably close after elevated platforms
    }

    void Cloud()
    {
        var height = RandomHeight(0.2f, 1.0f);
        var pos = new Vector3(endOfPlatform.x, endOfPlatform.y + height);
        platformSpwn.SpawnCloud(pos);
        endOfPlatform = new Vector3(endOfPlatform.x + Random.Range(0.64f, 1.28f), endOfPlatform.y);
        empties += 1; //we want a platform reasonably close after elevated platforms
    }
    
    /// <summary>
    /// Generates random number to decide what platform will spawn
    /// </summary>
    /// <returns>Randomly generated float</returns>
    float generateRandom()
    {
        if (empties < 2)        
        {
            return Random.Range(0.0f, 10.0f);
        }
        else   // there are 2 empty blocks in a row, we need to generate a platform or the gap will be too big to jump
        {
            return Random.Range(0.0f, 7.0f); //excludes the top X percent in which no platform generates
        }
    }
    
    /// <summary>
    /// Generates random height for half platforms and clouds
    /// </summary>
    /// <returns></returns>
    private float RandomHeight(float low, float high)
    {
        return Random.Range(low, high);
    }
}
