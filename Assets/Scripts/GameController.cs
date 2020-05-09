using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemy_obj;
    public PlayerController playerController;

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        float randomTimer;
        randomTimer = Random.Range(1f,2f);

        StartCoroutine(SpawnTimer(randomTimer));
    }

    private IEnumerator SpawnTimer(float timer)
    {
        yield return new WaitForSeconds(timer);

        GameObject enemy = Instantiate(enemy_obj, Vector2.zero, Quaternion.identity);
        int direction; //1 = dari kiri | 2 = dari kanan
        direction = Random.Range(1,3);

        if (direction == 1)
        {
            enemy.transform.localPosition = new Vector2(-10,-4.22f);
            enemy.GetComponent<EnemyController>().multiply = 1;
        }
        if (direction == 2)
        {
            enemy.transform.localPosition = new Vector2(10, -4.22f);
            enemy.GetComponent<EnemyController>().multiply = -1;
        }
        else
        {
            enemy.transform.localPosition = new Vector2(-10, -4.22f);
            enemy.GetComponent<EnemyController>().multiply = 1;
        }

        SpawnEnemies();
    }
}
