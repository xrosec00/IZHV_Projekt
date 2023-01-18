using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/**
 * Class PlatformSpawner
 * spawns a full block or a half block platform
 */
public class PlatformSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject halfGroundPrefab;
    public GameObject cloudPrefab;

    /// <summary>
    /// Spawns platoform
    /// </summary>
    /// <param name="pos"> position of spawned platform</param>
    public void SpawnPlatform(Vector3 pos)
    {
        var instance = Instantiate(groundPrefab, pos, transform.rotation);
        instance.GetComponent<PrefabLogic>().setInstance(instance);
    }
    
    /// <summary>
    /// Spawns half platform
    /// </summary>
    /// <param name="pos"> position of spawned half platform</param>
    public void SpawnHalfPlatform(Vector3 pos)
    {
        var instance = Instantiate(halfGroundPrefab, pos, transform.rotation);
        instance.GetComponent<PrefabLogic>().setInstance(instance);
    }

    /// <summary>
    /// Spawns cloud
    /// </summary>
    /// <param name="pos"> position of spawned cloud</param>
    public void SpawnCloud(Vector3 pos)
    {
        var instance = Instantiate(cloudPrefab, pos, transform.rotation);
        instance.GetComponent<PrefabLogic>().setInstance(instance);
    }

    
}
