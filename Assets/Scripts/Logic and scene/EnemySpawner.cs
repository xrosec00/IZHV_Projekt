using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public void SpawnEnemy(Vector3 pos)
    {
        Debug.Log("Enemy spawned at position " + pos);
        var instance = Instantiate(prefab, pos, transform.rotation);
        instance.GetComponent<EnemyLogic>().setInstance(instance);
    }
}
