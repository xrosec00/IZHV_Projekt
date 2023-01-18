using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLogic : MonoBehaviour
{
    private GameObject player;

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void FixedUpdate()
    {
        var difference = player.transform.position.x - prefab.transform.position.x;
        if (difference > 20.0f)
        {
            Debug.Log("Destroy");
            Destroy(prefab);
        }
    }

    public void setInstance(GameObject instance)
    {
        prefab = instance;
    }
}
