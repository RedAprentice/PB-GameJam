using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPositions;

    bool spawnTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !spawnTriggered)
        {
            spawnTriggered = true;
            for (int i = 0; i < enemies.Length; i++)
            {
                Instantiate(enemies[i]);
                enemies[i].transform.localPosition = spawnPositions[i].position;

                Debug.Log(enemies[i].transform.position + " " + spawnPositions[i].position);
            }
        }
    }
}
