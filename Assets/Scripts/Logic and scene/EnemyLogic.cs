using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int health;
    public GameObject enemy;
    private SkeletonEnemyScript enemyScript;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyScript = gameObject.GetComponent<SkeletonEnemyScript>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var difference =  player.transform.position.x - enemy.transform.position.x;
        if (health <= 0 || enemy.transform.position.y < -10.0f || difference > 20.0f)
        {
            Die();
        }
        
    }

    public void GetHit()
    {
        health -= 1;
    }

    void Die()
    {
        enemyScript.GetComponent<Rigidbody2D>().AddForce(new Vector2(1.0f, 3.0f));
        Physics2D.IgnoreLayerCollision(3,3);        //so we dont lose health by walking into dying enemy
        enemyScript.Die();  //death animation
        StartCoroutine(WaitFor());
    }

    private IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(enemy);
    }

    public void setInstance(GameObject instance)
    {
        enemy = instance;
    }
}
