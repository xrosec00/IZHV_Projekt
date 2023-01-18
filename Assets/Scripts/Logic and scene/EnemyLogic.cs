using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int health;
    public GameObject enemy;
    private SkeletonEnemyScript enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject;
        enemyScript = gameObject.GetComponent<SkeletonEnemyScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0 || enemy.transform.position.y < -10.0f)
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
        //enemyScript.GetComponent<BoxCollider2D>().enabled = false;  
        enemyScript.Die();  //death animation
        StartCoroutine(WaitFor());
    }

    private IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(enemy);
    }
}
